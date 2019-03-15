using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JsonHelper;
using JwtService;
using LogModule.Bll;
using LogModule.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserModule.Bll;
using ZwkProject.Model.Token;

namespace ZwkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IOptions<JwtConfig> _config;
        private readonly UserBll _userBll;
        private readonly LogBll _logBll;

        public TokenController(IOptions<JwtConfig> config, UserBll userBll, LogBll logBll)
        {
            _config = config;
            _userBll = userBll;
            _logBll = logBll;
        }

        [Route("/api/token/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginReq req)
        {
            var log = new OperatingLog();
            log.Create("");
            log.Summary = req.UserName + "尝试登录";
            var user = await _userBll.LoginAsync(req.UserName, req.Password);
            if (user == null)
            {
                await _logBll.AddAsync(log);
                return new JsonResult(new { success = false, message = "用户不存在" });
            }
            else
            {
                log.Create(user.PrimaryKey);
                log.Model = Json.Serialize(user);
                log.LinkId = user.PrimaryKey;
                await _logBll.AddAsync(log);
            }

            var claims = new[]
            {
                new Claim("name", user.UserName),
                new Claim("id", user.PrimaryKey),
                new Claim("role", "admin"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config.Value.Issuer, _config.Value.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(_config.Value.Expired), creds);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { success = true, token = result });
        }

        [Route("/api/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> ReFresh(RequestUser req)
        {
            var user = await _userBll.ValidateAsync(req.UserId, req.UserName);
            if (user == null)
                return new JsonResult(new { success = false, message = "用户不存在" });

            var claims = new[]
            {
                new Claim("name", user.UserName),
                new Claim("id", user.PrimaryKey),
                new Claim("role", "admin"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config.Value.Issuer, _config.Value.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(_config.Value.Expired), creds);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { success = true, token = result });
        }

    }
}