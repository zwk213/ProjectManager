using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Achieve;
using EFHelper.Interface;
using JwtService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectDatabase;

namespace ZwkProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region 依赖注入
            services.AddDbContext<ProjectDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
            services.AddScoped(typeof(DbContext), typeof(ProjectDbContext));
            services.AddScoped(typeof(IDataLayer<>), typeof(DataLayer<>));
            //获取所有模块
            AssemblyName[] assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(p => p.Name.EndsWith("Module")).ToArray();
            List<Assembly> assemblyList = assemblyNames.Select(Assembly.Load).ToList();
            //注入各模块的业务
            var blls = assemblyList.SelectMany(p => p.DefinedTypes).Where(p => p.Name.EndsWith("Bll")).ToList();
            blls.ForEach(p => { services.AddScoped(p); });
            //jwt
            services.AddScoped(typeof(ISecurityTokenValidator), typeof(JwtTokenValidator));
            #endregion

            #region jwt验证
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            var jwtConfig = new JwtConfig();
            Configuration.Bind("JwtConfig", jwtConfig);
            services
                .AddAuthentication(option =>
                {
                    //认证middleware配置
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Token颁发机构
                        ValidIssuer = jwtConfig.Issuer,
                        //颁发给谁
                        ValidAudience = jwtConfig.Audience,
                        //这里的key要进行加密
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey)),
                        //是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                        ValidateLifetime = true,
                    };
                });
            #endregion

            #region 跨域

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //使用测试环境异常信息页 
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //https传输
                app.UseHsts();
            }

            app.UseMiddleware<Mid>();

            //跨域
            app.UseCors("AllowAllOrigin");
            //配置Jwt授权
            app.UseAuthentication();
            //https重定向
            //app.UseHttpsRedirection();
            //mvc模式
            app.UseMvc();
        }
    }
}
