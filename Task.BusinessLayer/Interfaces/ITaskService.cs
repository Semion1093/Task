using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task DeleteTask(TaskModel taskModel);
        Task<List<TaskModel>> GetAllTasks();
        Task<List<TaskModel>> GetTasksByProjectId(Guid id);
        Task<TaskModel> GetTaskById(Guid id);
        Task UpdateTask(TaskModel taskModel);
    }
}