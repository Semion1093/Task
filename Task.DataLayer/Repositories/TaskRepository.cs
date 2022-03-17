using AutoMapper;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;
using Task.DataLayer.Entities;

namespace Task.DataLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private TaskContext _context;
        private IMapper _mapper;

        public TaskRepository(TaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TaskModel> GetAllTasks()
        {
            var tasksDto = _context.Tasks.Where(t => !t.IsDeleted).ToList();

            return _mapper.Map<List<TaskModel>>(tasksDto);
        }

        public TaskModel GetTaskById(int id)
        {
            var taskDto = _context.Tasks.Where(t => t.Id == id).FirstOrDefault();

            return _mapper.Map<TaskModel>(taskDto);
        }

        public List<TaskModel> GetTasksByProjectId(int id)
        {
            var tasksDto = _context.Tasks.Where(t => t.Project.Id == id).Where(x => !x.IsDeleted).ToList();

            return _mapper.Map<List<TaskModel>>(tasksDto);
        }

        public void UpdateTask(TaskModel taskModel)
        {
            var tasktDto = _mapper.Map<TaskDto>(taskModel);
            _context.Update(tasktDto);
            _context.SaveChanges();
        }

        public void DeleteTask(TaskModel taskModel)
        {
            var tasktDto = _mapper.Map<TaskDto>(taskModel);
            _context.Entry(new TaskDto { Id = tasktDto.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            _context.SaveChanges();
        }

    }
}
