using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Travel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Web.Admin.Controllers
{
    public class ProjectController : TravelAppControllerBase
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var projects = (await _projectAppService.GetPaged(new Travel.Dtos.GetProjectsInput())).Items; // Paging not implemented yet
           
            return View(projects);
        }
    }
}
