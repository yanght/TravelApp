using System.Collections.Generic;
using TravelApp.Roles.Dto;
using TravelApp.Users.Dto;

namespace TravelApp.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
