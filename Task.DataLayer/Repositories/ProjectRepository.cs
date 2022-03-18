using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;
using TestTask.DataLayer.Entities;

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
            var projectDto = _mapper.Map<ProjectDto>(projectModel);
            var addedProject = _context.Projects.Add(projectDto);
            await _context.SaveChangesAsync();

            return addedProject.Entity.Id;
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            var projectsDto = await _context.Projects.Where(p => !p.IsDeleted).ToListAsync(); ;

            return _mapper.Map<List<ProjectModel>>(projectsDto);
        }

        public async Task <ProjectModel> GetProjectById(Guid id)
        {
            var projectDto = await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProjectModel>(projectDto);
        }

        public async Task UpdateProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<ProjectDto>(projectModel);
            _context.Update(projectDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(ProjectModel projectModel)
        {
            var projectDto = _mapper.Map<ProjectModel>(projectModel);
            _context.Entry(new ProjectDto { Id = projectDto.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
