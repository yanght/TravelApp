
using Abp.Runtime.Validation;
using TravelApp.Dtos;
using TravelApp.Travel;

namespace TravelApp.Travel.Dtos
{
    public class GetCategorysInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
