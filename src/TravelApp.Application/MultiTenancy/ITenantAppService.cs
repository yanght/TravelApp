﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TravelApp.MultiTenancy.Dto;

namespace TravelApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

