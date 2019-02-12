using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TravelApp.Controllers;

namespace TravelApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TravelAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
