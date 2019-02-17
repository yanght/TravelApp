using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace TravelApp.Web.Views
{
    public abstract class TravelAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TravelAppRazorPage()
        {
            LocalizationSourceName = TravelAppConsts.LocalizationSourceName;
        }
    }
}
