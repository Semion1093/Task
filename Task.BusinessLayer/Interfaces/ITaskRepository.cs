using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Interfaces
{
    public interface ITaskRepository
    {
        void DeleteTask(TaskModel taskModel);
        List<TaskModel> GetAllTasks();
        List<TaskModel> GetTasksByProjectId(int id);
        TaskModel GetTaskById(int id);
        void UpdateTask(TaskModel taskModel);
    }
}