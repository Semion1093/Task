using AutoMapper;
using TestTask.BusinessLayer.Models;
using TestTask.DataLayer.Entities;

namespace TestTask.BusinessLayer.Configuration
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<TaskDto, TaskModel>().ReverseMap();

            CreateMap<ProjectDto, ProjectModel>().ReverseMap();
        }
    }
}
