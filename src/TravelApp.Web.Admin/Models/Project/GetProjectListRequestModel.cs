using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Web.Admin.Models.Project
{
    public class GetProjectListRequestModel : PageRequestModel
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int State { get; set; }
        public bool IsRecommend { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
