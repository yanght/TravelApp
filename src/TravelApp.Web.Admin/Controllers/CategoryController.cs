using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Controllers;
using TravelApp.Travel.Categorys;
using TravelApp.Travel.Categorys.Dtos;
using TravelApp.Web.Admin.Models.Category;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Web.Admin.Controllers
{
    public class CategoryController : TravelAppControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [DontWrapResult]
        public async Task<JsonResult> GetCategoryTree()
        {
            List<CategoryTreeViewModel> treeViewModelList = new List<CategoryTreeViewModel>();
            var list = (await _categoryAppService.GetPaged(new Travel.Categorys.Dtos.GetCategorysInput() { SkipCount = 0, MaxResultCount = 10, Sorting = "", FilterText = "" })).Items;
            var treeList = GetCategoryTree(0, list);
            treeViewModelList.Add(new CategoryTreeViewModel() { Id = 0, Checked = false, Children = treeList, Name = "所有分类", Open = true });
            return Json(treeViewModelList);
        }

        private List<CategoryTreeViewModel> GetCategoryTree(int parentId, IReadOnlyList<CategoryListDto> list)
        {
            if (list == null || list.Count == 0) return null;
            List<CategoryTreeViewModel> treeViewModelList = new List<CategoryTreeViewModel>();
            var result = list.Where(m => m.ParentId == parentId).ToList();
            foreach (var item in result)
            {
                CategoryTreeViewModel model = new CategoryTreeViewModel()
                {
                    Checked = false,
                    Id = item.Id,
                    Name = item.CategoryName,
                    Open = false,
                    Children = GetCategoryTree(item.Id, list)
                };
                treeViewModelList.Add(model);
            }
            return treeViewModelList.Count() == 0 ? null : treeViewModelList;
        }
    }
}
