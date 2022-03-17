using AutoMapper;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;
using Task.DataLayer.Entities;

namespace Task.DataLayer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private TaskContext _context;
        private IMapper _mapper;

        public ProjectRepository(TaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int AddProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<ProjectDto>(projectModel);
            var addedProject = _context.Projects.Add(projectDto);
            _context.SaveChanges();

            return addedProject.Entity.Id;
        }

        public List<ProjectModel> GetAllProjects()
        {
            var projectsDto = _context.Projects.Where(p => !p.IsDeleted).ToList(); ;

            return _mapper.Map<List<ProjectModel>>(projectsDto);
        }

        public ProjectModel GetProjectById(int id)
        {
            var projectDto = _context.Projects.Where(p => p.Id == id).FirstOrDefault();

            return _mapper.Map<ProjectModel>(projectDto);
        }

        public void UpdateProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<ProjectDto>(projectModel);
            _context.Update(projectDto);
            _context.SaveChanges();
        }

        public void DeleteProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<ProjectModel>(projectModel);
            _context.Entry(new ProjectDto { Id = projectDto.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            _context.SaveChanges();
        }
    }
}
