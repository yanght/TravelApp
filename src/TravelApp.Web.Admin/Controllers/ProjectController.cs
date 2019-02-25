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
using TravelApp.Travel.Categorys;
using TravelApp.Travel.Dtos;
using TravelApp.Web.Admin.Models;
using TravelApp.Web.Admin.Models.Project;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Web.Admin.Controllers
{
    public class ProjectController : TravelAppControllerBase
    {
        private readonly IProjectAppService _projectAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ProjectController(IProjectAppService projectAppService,
            ICategoryAppService categoryAppService)
        {
            _projectAppService = projectAppService;
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int projectId)
        {
            var project = await _projectAppService.GetById(new Abp.Application.Services.Dto.EntityDto<int>() { Id = projectId });
            var category = await _categoryAppService.GetById(new Abp.Application.Services.Dto.EntityDto<int>() { Id = project.CategoryId });

            return View(new EditProjectViewModel() { Project = project, Category = category });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
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
            var result = (await _projectAppService.GetProjectList(input));
            return Json(new TableJsonResult() { code = 0, count = result.TotalCount, data = result.Items, msg = "" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> EditProject(CreateOrUpdateProjectInput requestModel)
        {
            await _projectAppService.CreateOrUpdate(requestModel);
            return Json(true);
        }
    }
}
