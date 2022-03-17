using AutoMapper;
using Task.API.Models;
using Task.BusinessLayer.Models;

namespace Task.API.Configuration
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<TaskUpdateModel, TaskModel>();
            CreateMap<TaskModel, TaskOutputModel>();

            CreateMap<ProjectInputModel, ProjectModel>();
            CreateMap<ProjectUpdateModel, ProjectModel>();
            CreateMap<ProjectModel, ProjectOutputModel>();
        }
    }
}
