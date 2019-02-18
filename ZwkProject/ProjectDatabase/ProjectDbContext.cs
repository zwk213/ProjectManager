using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LogModule.Map;
using Microsoft.EntityFrameworkCore;
using ProjectModule.Map;
using UserMap = UserModule.Map.UserMap;

namespace ProjectDatabase
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //项目中各模块model与map的匹配
            AssemblyName[] assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies()
                .Where(p => p.Name.EndsWith("Module")).ToArray();
            List<Assembly> assemblyList = assemblyNames.Select(Assembly.Load).ToList();
            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            foreach (var assembly in assemblyList)
            {
                var mappingTypes = assembly.GetTypes()
                    .Where(x => x.GetInterfaces().Any(y =>
                        y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
                var entityMethod = typeof(ModelBuilder).GetMethods()
                    .Single(x => x.Name == "Entity" &&
                                 x.IsGenericMethod &&
                                 x.ReturnType.Name == "EntityTypeBuilder`1");
                foreach (var mappingType in mappingTypes)
                {
                    var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                    var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                    var entityBuilder = genericEntityMethod.Invoke(builder, null);
                    var mapper = Activator.CreateInstance(mappingType);
                    mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
                }
            }
        }

    }
}
