using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface IProjectService
    {
        Task<Guid> AddProject(ProjectModel projectModel);
        Task DeleteProject(ProjectModel projectModel);
        Task<List<ProjectModel>> GetAllProjects();
        Task<ProjectModel> GetProjectById(Guid id);
        Task UpdateProject(ProjectModel projectModel);
    }
}