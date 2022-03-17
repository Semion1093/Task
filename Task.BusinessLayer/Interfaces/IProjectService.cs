using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Interfaces
{
    public interface IProjectService
    {
        int AddProject(ProjectModel projectModel);
        void DeleteProject(ProjectModel projectModel);
        List<ProjectModel> GetAllProjects();
        ProjectModel GetProjectById(int id);
        void UpdateProject(ProjectModel projectModel);
    }
}