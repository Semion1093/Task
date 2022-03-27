using AutoMapper;
using TestTask.BusinessLayer.Models;
using TestTask.DataLayer.Entities;

namespace TestTask.BusinessLayer.Configuration
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<DataLayer.Entities.Task, TaskModel>()
                .ForPath(dest => dest.ProjectId, opt => opt.MapFrom(srs => srs.Project.Id))
                .ReverseMap();

            CreateMap<Project, ProjectModel>().ReverseMap();
        }
    }
}
