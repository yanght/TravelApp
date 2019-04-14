using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Travel;

namespace TravelApp.Web.Admin.Controllers
{
    public class TripController : TravelAppControllerBase
    {
        private readonly ITripAppService _tipAppService;

        public TripController(ITripAppService tripAppService)
        {
            _tipAppService = tripAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EditTrip(int? tripId)
        {
            var tripForEdit = await _tipAppService.GetForEdit(new Abp.Application.Services.Dto.NullableIdDto<int>() { Id = tripId });
            return View(tripForEdit);
        }

        public IActionResult TripAttendList()
        {
            return View();
        }
    }
}