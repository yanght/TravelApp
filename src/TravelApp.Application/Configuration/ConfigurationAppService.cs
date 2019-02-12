using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TravelApp.Configuration.Dto;

namespace TravelApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TravelAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
