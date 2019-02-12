using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TravelApp.Controllers
{
    public abstract class TravelAppControllerBase: AbpController
    {
        protected TravelAppControllerBase()
        {
            LocalizationSourceName = TravelAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
