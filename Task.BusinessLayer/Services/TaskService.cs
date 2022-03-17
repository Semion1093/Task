using Task.BusinessLayer.Exeptions;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskModel GetTaskById(int id)
        {
            var taskModel = _taskRepository.GetTaskById(id);

            if (taskModel is null)
                throw new EntityNotFoundException($"Task wasn't found");

            return taskModel;
        }

        public List<TaskModel> GetTasksByProjectId(int id)
        {
            return _taskRepository.GetTasksByProjectId(id);
        }

        public List<TaskModel> GetAllTasks()
        {
            var taskModels = _taskRepository.GetAllTasks();
            return taskModels;
        }

        public void UpdateTask(TaskModel taskModel)
        {
            _taskRepository.UpdateTask(taskModel);
        }

        public void DeleteTask(TaskModel taskModel)
        {
            _taskRepository.DeleteTask(taskModel);
        }
    }
}
