
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
using TravelApp.Travel.Projects.Dtos;
using TravelApp.Users.Dto;
using TravelApp.Travel.Trips;
using TravelApp.Travel.Trips.Dtos;

namespace TravelApp.Travel
{
    /// <summary>
    /// Project应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    [DisableValidation]
    public class TripApplicationService : TravelAppAppServiceBase, ITripApplicationService
    {
        private readonly IRepository<Trip, int> _entityRepository;

        private readonly IDapperRepository<Trip> _tripDapperRepository;


        /// <summary>
        /// 构造函数 
        ///</summary>
        public TripApplicationService(
        IRepository<Trip, int> entityRepository
            , IDapperRepository<Trip> tripDapperRepository
        )
        {
            _entityRepository = entityRepository;
            _tripDapperRepository = tripDapperRepository;
        }

        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdate(TripDto input)
        {

            if (input.Id > 0)
            {
                await Update(input);
            }
            else
            {
                await Create(input);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        protected virtual async Task<TripDto> Create(TripDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<TripDto, Trip>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<Trip, TripDto>();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        protected virtual async Task Update(TripDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id);
            input.MapTo(entity);

            await _entityRepository.UpdateAsync(entity);
        }

        public virtual async Task<TripDto> GetById(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<Trip, TripDto>();
        }

        public virtual async Task<PagedResultDto<TripDto>> GetPaged(GetTripsInput input)
        {
            var query = _entityRepository.GetAll();

            var count = await query.CountAsync();

            var entityList = await query
                   .OrderBy(input.Sorting).AsNoTracking()
                   .PageBy(input)
                   .ToListAsync();

            var entityListDtos = entityList.MapToList<Trip, TripDto>().ToList();

            return new PagedResultDto<TripDto>(count, entityListDtos);
        }
    }
}


