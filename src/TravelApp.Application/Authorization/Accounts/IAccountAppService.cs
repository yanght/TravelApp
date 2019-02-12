using System.Threading.Tasks;
using Abp.Application.Services;
using TravelApp.Authorization.Accounts.Dto;

namespace TravelApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
