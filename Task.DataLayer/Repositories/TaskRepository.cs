using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;
using TestTask.DataLayer.Entities;

namespace TestTask.DataLayer.Repositories
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

        public async Task<List<TaskModel>> GetAllTasks()
        {
            var tasksDto = await _context.Tasks.Where(t => !t.IsDeleted).ToListAsync();

            return _mapper.Map<List<TaskModel>>(tasksDto);
        }

        public async Task<TaskModel> GetTaskById(Guid id)
        {
            var taskDto = await _context.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<TaskModel>(taskDto);
        }

        public async Task<List<TaskModel>> GetTasksByProjectId(Guid id)
        {
            var tasksDto = await _context.Tasks
                .Where(t => t.Project.Id == id)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<TaskModel>>(tasksDto);
        }

        public async Task UpdateTask(TaskModel taskModel)
        {
            var tasktDto = _mapper.Map<TaskDto>(taskModel);
            _context.Update(tasktDto);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(TaskModel taskModel)
        {
            var tasktDto = _mapper.Map<TaskDto>(taskModel);

            _context.Entry(new TaskDto { Id = tasktDto.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}
