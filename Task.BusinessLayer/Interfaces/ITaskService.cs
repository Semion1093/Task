using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        void DeleteTask(TaskModel taskModel);
        List<TaskModel> GetAllTasks();
        List<TaskModel> GetTasksByProjectId(int id);
        TaskModel GetTaskById(int id);
        void UpdateTask(TaskModel taskModel);
    }
}