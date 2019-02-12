using Abp.Authorization;
using TravelApp.Authorization.Roles;
using TravelApp.Authorization.Users;

namespace TravelApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
