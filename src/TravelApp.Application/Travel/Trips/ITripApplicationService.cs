
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
using Abp.Application.Services;
using TravelApp.Travel.Trips.Dtos;

namespace TravelApp.Travel
{
    public interface ITripAppService : IApplicationService
    {
        /// <summary>
        /// 获取Trip的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<TripDto>> GetPaged(GetTripsInput input);

        /// <summary>
        /// 通过指定id获取信息
        /// </summary>
        Task<TripDto> GetById(EntityDto<int> input);

        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TripDto> GetForEdit(NullableIdDto<int> input);

        /// <summary>
        /// 删除行程 逻辑删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);

        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(TripDto input);

        /// <summary>
        /// 修改行程状态 1 正常  0 未审核
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ChangeTripState(ChangeTripStateDto input);
    }
}


