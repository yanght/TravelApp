using System.Threading.Tasks;
using Abp.Application.Services;
using TravelApp.Sessions.Dto;

namespace TravelApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
