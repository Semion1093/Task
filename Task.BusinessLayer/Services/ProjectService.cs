using Task.BusinessLayer.Exeptions;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public int AddProject(ProjectModel projectModel)
        {
            var projectId = _projectRepository.AddProject(projectModel);

            return projectId;
        }

        public ProjectModel GetProjectById(int id)
        {
            var projectModel = _projectRepository.GetProjectById(id);

            if (projectModel is null)
                throw new EntityNotFoundException($"Project wasn't found");

            return projectModel;
        }

        public List<ProjectModel> GetAllProjects()
        {
            var projectModels = _projectRepository.GetAllProjects();
            return projectModels;
        }

        public void UpdateProject(ProjectModel projectModel)
        {
            _projectRepository.UpdateProject(projectModel);
        }

        public void DeleteProject(ProjectModel projectModel)
        {
            _projectRepository.DeleteProject(projectModel);
        }
    }
}
