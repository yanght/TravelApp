using Abp.AspNetCore.Mvc.ViewComponents;

namespace TravelApp.Web.Views
{
    public abstract class TravelAppViewComponent : AbpViewComponent
    {
        protected TravelAppViewComponent()
        {
            LocalizationSourceName = TravelAppConsts.LocalizationSourceName;
        }
    }
}
