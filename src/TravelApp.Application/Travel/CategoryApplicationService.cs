
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using TravelApp.Travel;
using TravelApp.Travel.Dtos;
using TravelApp.Travel.DomainService;
using TravelApp.Travel.Authorization;
using Abp.Dapper.Repositories;

namespace TravelApp.Travel
{
    /// <summary>
    /// Category应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class CategoryAppService : TravelAppAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category, int> _entityRepository;

        private readonly ICategoryManager _entityManager;

        private readonly IDapperRepository<Category> _categoryDapperRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public CategoryAppService(
        IRepository<Category, int> entityRepository
        , ICategoryManager entityManager,
        IDapperRepository<Category> categoryDapperRepository
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
            _categoryDapperRepository = categoryDapperRepository;
        }


        /// <summary>
        /// 获取Category的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(CategoryPermissions.Query)]
        public async Task<PagedResultDto<CategoryListDto>> GetPaged(GetCategorysInput input)
        {
            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<CategoryListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<CategoryListDto>>();

            return new PagedResultDto<CategoryListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取CategoryListDto信息
        /// </summary>
        [AbpAuthorize(CategoryPermissions.Query)]
        public async Task<CategoryListDto> GetById(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<CategoryListDto>();
        }

        /// <summary>
        /// 获取编辑 Category
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(CategoryPermissions.Create, CategoryPermissions.Edit)]
        public async Task<GetCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetCategoryForEditOutput();
            CategoryEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<CategoryEditDto>();

                //categoryEditDto = ObjectMapper.Map<List<categoryEditDto>>(entity);
            }
            else
            {
                editDto = new CategoryEditDto();
            }

            output.Category = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Category的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(CategoryPermissions.Create, CategoryPermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateCategoryInput input)
        {

            if (input.Category.Id.HasValue)
            {
                await Update(input.Category);
            }
            else
            {
                await Create(input.Category);
            }
        }


        /// <summary>
        /// 新增Category
        /// </summary>
        [AbpAuthorize(CategoryPermissions.Create)]
        protected virtual async Task<CategoryEditDto> Create(CategoryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Category>(input);
            var entity = input.MapTo<Category>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<CategoryEditDto>();
        }

        /// <summary>
        /// 编辑Category
        /// </summary>
        [AbpAuthorize(CategoryPermissions.Edit)]
        protected virtual async Task Update(CategoryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Category信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(CategoryPermissions.Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Category的方法
        /// </summary>
        [AbpAuthorize(CategoryPermissions.BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<CategoryListDto> FindById(int id)
        {
            var entity = await _categoryDapperRepository.GetAsync(id);
            return entity.MapTo<CategoryListDto>();
        }

        /// <summary>
        /// 导出Category为excel表,等待开发。
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetToExcel()
        //{
        //	var users = await UserManager.Users.ToListAsync();
        //	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //	await FillRoleNames(userListDtos);
        //	return _userListExcelExporter.ExportToFile(userListDtos);
        //}

    }
}


