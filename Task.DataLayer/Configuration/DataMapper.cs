using AutoMapper;
using Task.BusinessLayer.Models;
using Task.DataLayer.Entities;

namespace Task.BusinessLayer.Configuration
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
