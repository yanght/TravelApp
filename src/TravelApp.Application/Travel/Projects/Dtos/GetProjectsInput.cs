
using Abp.Runtime.Validation;
using System;
using TravelApp.Dtos;
using TravelApp.Travel;

namespace TravelApp.Travel.Dtos
{
    public class GetProjectsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int State { get; set; }
        public bool IsRecommend { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


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
