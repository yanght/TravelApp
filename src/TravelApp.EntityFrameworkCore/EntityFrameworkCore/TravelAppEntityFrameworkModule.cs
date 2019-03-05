using Abp.Dapper;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using TravelApp.EntityFrameworkCore.Seed;

namespace TravelApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(TravelAppCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(AbpDapperModule))]
    public class TravelAppEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TravelAppDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        TravelAppDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        TravelAppDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TravelAppEntityFrameworkModule).GetAssembly());

            //这里会自动去扫描程序集中配置好的映射关系
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(TravelAppEntityFrameworkModule).GetAssembly() });

        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
