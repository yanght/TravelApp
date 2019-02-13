using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Travel;
using TravelApp.Users.Dto;
using Dapper;
using DapperExtensions;
using TravelApp.Web.Models.Travel;
using TravelApp.Authorization;
using Abp.AspNetCore.Mvc.Authorization;
using TravelApp.Travel.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Web.Controllers
{
    [AbpMvcAuthorize(ProjectPermissions.Node)]
    public class ProjectsController : TravelAppControllerBase
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectsController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var projects = (await _projectAppService.GetPaged(new Travel.Dtos.GetProjectsInput())).Items; // Paging not implemented yet
            var model = new ProjectListViewModel()
            {
                Projects = projects
            };
            return View(model);
        }
    }
}
