using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Travel;
using TravelApp.Travel.Trips.Dtos;

namespace TravelApp.Web.Admin.Controllers
{
    public class BrowseController : TravelAppControllerBase
    {
        private readonly ITripAppService _tipAppService;

        public BrowseController(ITripAppService tripAppService)
        {
            _tipAppService = tripAppService;
        }
        public async Task<IActionResult> Index(int id)
        {
            TripDto trip = await _tipAppService.GetById(new Abp.Application.Services.Dto.EntityDto<int>()
            {
                Id = id
            });
            if (trip == null || string.IsNullOrEmpty(trip.TripDesc))
            {
                return Content("行程不存在");
            }
            return View(trip);
        }
    }
}