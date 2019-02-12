using Microsoft.AspNetCore.Antiforgery;
using TravelApp.Controllers;

namespace TravelApp.Web.Host.Controllers
{
    public class AntiForgeryController : TravelAppControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
