using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Travel;
using TravelApp.Travel.Dtos;
using TravelApp.Web.Admin.Models;
using TravelApp.Web.Admin.Models.Project;

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

        public IActionResult Index()
        {
            return View();
        }

        [DontWrapResult]
        public async Task<JsonResult> ProjectList(GetProjectListRequestModel requestModel)
        {
            var input = new GetProjectsInput()
            {
                CategoryId = requestModel.CategoryId,
                EndTime = requestModel.EndTime,
                IsRecommend = requestModel.IsRecommend,
                Name = requestModel.Name,
                StartTime = requestModel.StartTime,
                State = requestModel.State,
                MaxResultCount = requestModel.limit,
                SkipCount = (requestModel.page - 1) * requestModel.limit,
                Sorting = ""
            };
            var result = (await _projectAppService.GetPaged(input));
            return Json(new TableJsonResult() { code = 0, count = result.TotalCount, data = result.Items, msg = "" });
        }


        public IActionResult AddProject()
        {
            return View();
        }
    }
}
