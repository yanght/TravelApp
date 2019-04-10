
using AutoMapper;
using TravelApp.Travel;
using TravelApp.Travel.Dtos;
using TravelApp.Travel.Projects;

namespace TravelApp.Travel.Mapper
{

    /// <summary>
    /// 配置Project的AutoMapper
    /// </summary>
    internal static class ProjectMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Project, ProjectListDto>();
            configuration.CreateMap<ProjectListDto, Project>();

            configuration.CreateMap<ProjectEditDto, Project>();
            configuration.CreateMap<Project, ProjectEditDto>();


        }
    }
}
