using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TravelApp.Roles.Dto;
using TravelApp.Users.Dto;

namespace TravelApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
