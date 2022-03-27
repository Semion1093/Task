using TestTask.BusinessLayer.Exeptions;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Guid> AddTask(TaskModel taskModel)
        {
            var taskId = await _taskRepository.AddTask(taskModel);

            return taskId;
        }

        public async Task<TaskModel> GetTaskById(Guid id)
        {
            var taskModel = await _taskRepository.GetTaskById(id);

            if (taskModel is null)
                throw new EntityNotFoundException($"Task wasn't found");

            return taskModel;
        }

        public async Task<List<TaskModel>> GetTasksByProjectId(Guid id)
        {
            return await _taskRepository.GetTasksByProjectId(id);
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            var taskModels = await _taskRepository.GetAllTasks();
            return taskModels;
        }

        public async Task UpdateTask(TaskModel taskModel)
        {
            await _taskRepository.UpdateTask(taskModel);
        }

        public async Task DeleteTask(TaskModel taskModel)
        {
            await _taskRepository.DeleteTask(taskModel);
        }
    }
}
