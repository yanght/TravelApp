using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Travel.Dtos;

namespace TravelApp.Web.Models.Travel
{
    public class ProjectListViewModel
    {
        public IReadOnlyList<ProjectListDto> Projects { get; set; }
    }
}
