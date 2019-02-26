using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Travel.Projects.Dtos
{
    public class ProjectMapper : ClassMapper<Project>
    {
        public ProjectMapper()
        {
            Table("Project");
            AutoMap();
        }
    }
}