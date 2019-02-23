
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
using TravelApp.Travel.Projects;

namespace TravelApp.Travel
{
    /// <summary>
    /// Project应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ProjectAppService : TravelAppAppServiceBase, IProjectAppService
    {
        private readonly IRepository<Project, int> _entityRepository;

        private readonly IProjectManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProjectAppService(
        IRepository<Project, int> entityRepository
        , IProjectManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Project的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ProjectPermissions.Query)]
        public async Task<PagedResultDto<ProjectListDto>> GetPaged(GetProjectsInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(m => m.Name.Contains(input.Name));
            if (input.CategoryId > 0)
                query = query.Where(m => m.CategoryId == input.CategoryId);
            if (input.IsRecommend)
                query = query.Where(m => m.IsRecommend == input.IsRecommend);
            if (input.State != 0)
                query = query.Where(m => m.State == input.State);

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ProjectListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<ProjectListDto>>();

            return new PagedResultDto<ProjectListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ProjectListDto信息
        /// </summary>
        [AbpAuthorize(ProjectPermissions.Query)]
        public async Task<ProjectListDto> GetById(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<ProjectListDto>();
        }

        /// <summary>
        /// 获取编辑 Project
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProjectPermissions.Create, ProjectPermissions.Edit)]
        public async Task<GetProjectForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetProjectForEditOutput();
            ProjectEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<ProjectEditDto>();

                //projectEditDto = ObjectMapper.Map<List<projectEditDto>>(entity);
            }
            else
            {
                editDto = new ProjectEditDto();
            }

            output.Project = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Project的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProjectPermissions.Create, ProjectPermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateProjectInput input)
        {

            if (input.Project.Id.HasValue)
            {
                await Update(input.Project);
            }
            else
            {
                await Create(input.Project);
            }
        }


        /// <summary>
        /// 新增Project
        /// </summary>
        [AbpAuthorize(ProjectPermissions.Create)]
        protected virtual async Task<ProjectEditDto> Create(ProjectEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Project>(input);
            var entity = input.MapTo<Project>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<ProjectEditDto>();
        }

        /// <summary>
        /// 编辑Project
        /// </summary>
        [AbpAuthorize(ProjectPermissions.Edit)]
        protected virtual async Task Update(ProjectEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Project信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProjectPermissions.Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Project的方法
        /// </summary>
        [AbpAuthorize(ProjectPermissions.BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// 导出Project为excel表,等待开发。
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


