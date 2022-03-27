using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;
using TestTask.DataLayer.Entities;
using Task = System.Threading.Tasks.Task;

namespace TestTask.DataLayer.Repositories
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

        public async Task<Guid> AddProject(ProjectModel projectModel)
        {
            var project = _mapper.Map<Project>(projectModel);
            var addedProject = _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return addedProject.Entity.Id;
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            var projects = await _context.Projects
                .Where(p => !p.IsDeleted)
                .Include(p => p.Tasks)
                .ToListAsync(); ;

            return _mapper.Map<List<ProjectModel>>(projects);
        }

        public async Task <ProjectModel> GetProjectById(Guid id)
        {
            var project = await _context.Projects
                .Where(p => p.Id == id)
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync();

            return _mapper.Map<ProjectModel>(project);
        }

        public async Task UpdateProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<Project>(projectModel);
            _context.Update(projectDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<ProjectModel>(projectModel);
            _context.Entry(new Project { Id = projectDto.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
