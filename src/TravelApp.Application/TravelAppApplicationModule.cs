using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TravelApp.Authorization;
using TravelApp.Travel.Authorization;
using TravelApp.Travel.Mapper;

namespace TravelApp
{
    [DependsOn(
        typeof(TravelAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TravelAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TravelAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TravelAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
