
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
using TravelApp.Travel.TripAttends.Dtos;
using TravelApp.Travel.Trips.Dtos;

namespace TravelApp.Travel
{
    public interface ITripAttendAppService : IApplicationService
    {
        /// <summary>
        /// ��ȡ��ҳ�б���Ϣ
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<TripAttendDto>> GetPaged(GetTripAttendInput input);

        /// <summary>
        /// ͨ��ָ��id��ȡ��Ϣ
        /// </summary>
        Task<TripAttendDto> GetById(EntityDto<int> input);

        /// <summary>
        /// ����ʵ���EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TripAttendDto> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// ��ӻ����޸ĵĹ�������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(TripAttendDto input);

    }
}


