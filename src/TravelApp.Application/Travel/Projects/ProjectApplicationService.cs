
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
using Abp.Dapper.Repositories;
using System.Data.SqlClient;
using System.Data.Common;
using Abp.AutoMapper;
using TravelApp.Core;
using Abp.Runtime.Validation;

namespace TravelApp.Travel
{
    /// <summary>
    /// Project应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    [DisableValidation]
    public class ProjectAppService : TravelAppAppServiceBase, IProjectAppService
    {
        private readonly IRepository<Project, int> _entityRepository;

        private readonly IProjectManager _entityManager;

        private readonly IDapperRepository<Project> _projectDapperRepository;


        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProjectAppService(
        IRepository<Project, int> entityRepository
        , IProjectManager entityManager
            , IDapperRepository<Project> projectDapperRepository
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
            _projectDapperRepository = projectDapperRepository;
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
            var entityListDtos = entityList.MapToList<Project, ProjectListDto>().ToList();

            return new PagedResultDto<ProjectListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ProjectListDto信息
        /// </summary>
        [AbpAuthorize(ProjectPermissions.Query)]
        public async Task<ProjectListDto> GetById(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<Project, ProjectListDto>();
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

                editDto = entity.MapTo<Project, ProjectEditDto>();

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
            var entity = input.MapTo<ProjectEditDto, Project>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<Project, ProjectEditDto>();
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

        public async Task<PagedResultDto<ProjectListDto>> GetProjectList(GetProjectsInput input)
        {
            PagedResultDto<ProjectListDto> rtn = new PagedResultDto<ProjectListDto>();
            string pagesql = $"select top {input.MaxResultCount} * from(select row_number() over(order by id asc) as rownumber, * from({"{0}"}) as a) temp_row where rownumber > {input.SkipCount}";

            string sql = "select project.*,category.categoryName from project left join category on project.categoryId=category.id where 1=1 ";
            string whereSql = string.Empty;

            var predicate = PredicateBuilder.True<Project>();
            if (input.CategoryId != 0)
            {
                whereSql = " and project.CategoryId=@CategoryId";
                predicate = predicate.And(m => m.CategoryId == input.CategoryId);
            }
            if (!string.IsNullOrEmpty(input.Name))
            {
                whereSql += " and project.Name like @Name";
                predicate = predicate.And(m => m.Name.Contains(input.Name));
            }
            if (input.State != 0)
            {
                whereSql += " and project.State=@State";
                predicate = predicate.And(m => m.State == input.State);
            }
            if (input.StartTime != null)
            {
                whereSql += " and project.CreateTime>=@StartTime";
                predicate = predicate.And(m => m.CreateTime >= input.StartTime);
            }
            if (input.EndTime != null)
            {
                whereSql += " and project.CreateTime<=@EndTime";
                predicate = predicate.And(m => m.CreateTime <= input.EndTime);
            }
            sql += whereSql;

            string countsql = $"select count(1) from project where 1=1 {whereSql}";
            pagesql = string.Format(pagesql, sql);

            int totalCount = _entityRepository.Count(predicate);

            List<ProjectListDto> projectLit = (await _projectDapperRepository.QueryAsync<ProjectListDto>(pagesql, new
            {
                CategoryId = input.CategoryId,
                Name = $"%{input.Name}%",
                State = input.State,
                StartTime = input.StartTime,
                EndTime = input.EndTime
            })).ToList();
            rtn.Items = projectLit;
            rtn.TotalCount = totalCount;
            return rtn;
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


