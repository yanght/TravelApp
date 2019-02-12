using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TravelApp.Configuration;

namespace TravelApp.Web.Host.Startup
{
    [DependsOn(
       typeof(TravelAppWebCoreModule))]
    public class TravelAppWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TravelAppWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TravelAppWebHostModule).GetAssembly());
        }
    }
}
