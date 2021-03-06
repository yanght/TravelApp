﻿using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using TravelApp.Dtos;

namespace TravelApp.Travel.TripAttends.Dtos
{
    public class GetTripAttendInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
