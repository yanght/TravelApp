using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TravelApp.Controllers;

namespace TravelApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : TravelAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
