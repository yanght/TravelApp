using System.Threading.Tasks;
using TravelApp.Configuration.Dto;

namespace TravelApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
