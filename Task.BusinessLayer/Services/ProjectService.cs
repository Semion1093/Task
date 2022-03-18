using TestTask.BusinessLayer.Exeptions;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Guid> AddProject(ProjectModel projectModel)
        {
            var projectId = await _projectRepository.AddProject(projectModel);

            return projectId;
        }

        public async Task<ProjectModel> GetProjectById(Guid id)
        {
            var projectModel = await _projectRepository.GetProjectById(id);

            if (projectModel is null)
                throw new EntityNotFoundException($"Project wasn't found");

            return projectModel;
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            var projectModels = await _projectRepository.GetAllProjects();
            return projectModels;
        }

        public async Task UpdateProject(ProjectModel projectModel)
        {
            await _projectRepository.UpdateProject(projectModel);
        }

        public async Task DeleteProject(ProjectModel projectModel)
        {
            await _projectRepository.DeleteProject(projectModel);
        }
    }
}
