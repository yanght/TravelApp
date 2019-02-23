using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Travel.Categorys.Dtos;
using TravelApp.Travel.Dtos;

namespace TravelApp.Web.Admin.Models.Project
{
    public class EditProjectViewModel
    {
        public ProjectListDto Project { get; set; }
        public CategoryListDto Category { get; set; }
    }
}
