using AutoMapper;
using TestTask.API.Layer.Models;
using TestTask.BusinessLayer.Models;

namespace TestTask.API.Configuration
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<TaskInputModel, TaskModel>();
            CreateMap<TaskUpdateModel, TaskModel>();
            CreateMap<TaskInsertModel, TaskModel>();
            CreateMap<TaskModel, TaskOutputModel>();

            CreateMap<ProjectInputModel, ProjectModel>();
            CreateMap<ProjectUpdateModel, ProjectModel>();
            CreateMap<ProjectModel, ProjectOutputModel>();
        }
    }
}
