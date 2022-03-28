using AutoMapper;
using TestTask.BusinessLayer.Models;
using TestTask.DataLayer.Entities;
using Task = TestTask.DataLayer.Entities.Task;

namespace TestTask.BusinessLayer.Configuration
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<Task, TaskModel>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
        }
    }
}
