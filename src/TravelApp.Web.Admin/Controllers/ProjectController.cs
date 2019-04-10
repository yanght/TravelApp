using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Core;
using TravelApp.Travel;
using TravelApp.Travel.Categorys;
using TravelApp.Travel.Categorys.Dtos;
using TravelApp.Travel.Dtos;
using TravelApp.Web.Admin.Models;
using TravelApp.Web.Admin.Models.Project;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Web.Admin.Controllers
{
    [DisableValidation]
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
        public async Task<IActionResult> EditProject(int? projectId)
        {
            var category = new CategoryListDto();
            var projectForEdit = await _projectAppService.GetForEdit(new Abp.Application.Services.Dto.NullableIdDto<int>() { Id = projectId });
            if (projectForEdit.Project.Id.HasValue)
            {
                category = await _categoryAppService.GetById(new Abp.Application.Services.Dto.EntityDto<int>() { Id = projectForEdit.Project.CategoryId });
            }
            return View(new EditProjectViewModel() { Project = projectForEdit.Project, Category = category });
        }

        ///// <summary>
        ///// 线路列表
        ///// </summary>
        ///// <param name="requestModel"></param>
        ///// <returns></returns>
        //[DontWrapResult]
        //public async Task<JsonResult> ProjectList(GetProjectListRequestModel requestModel)
        //{            
        //       var input = new GetProjectsInput()
        //    {
        //        CategoryId = requestModel.CategoryId,
        //        EndTime = requestModel.EndTime,
        //        IsRecommend = requestModel.IsRecommend,
        //        Name = requestModel.Name,
        //        StartTime = requestModel.StartTime,
        //        State = requestModel.State,
        //        MaxResultCount = requestModel.limit,
        //        SkipCount = (requestModel.page - 1) * requestModel.limit,
        //        Sorting = ""
        //    };

        //    input = requestModel.MapTo<GetProjectListRequestModel, GetProjectsInput>();
        //    input.SkipCount = (requestModel.page - 1) * requestModel.limit;
        //    input.MaxResultCount = requestModel.limit;

        //    var result = (await _projectAppService.GetProjectList(input));
        //    return Json(new TableJsonResult() { code = 0, count = result.TotalCount, data = result.Items, msg = "" });
        //}

        ///// <summary>
        ///// 编辑线路
        ///// </summary>
        ///// <param name="requestModel"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<JsonResult> EditProject([FromBody]EditProjectRequestModel requestModel)
        //{
        //    var projectEditDto = requestModel.MapTo<EditProjectRequestModel, ProjectEditDto>();
        //    await _projectAppService.CreateOrUpdate(new CreateOrUpdateProjectInput() { Project = projectEditDto });
        //    return Json(new AjaxJsonResult(true));
        //}
    }
}
