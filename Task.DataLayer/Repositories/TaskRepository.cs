using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;
using Task = System.Threading.Tasks.Task;

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

        public async Task<Guid> AddTask(TaskModel taskModel)
        {
            var task = _mapper.Map<Entities.Task>(taskModel);
            var addedTask = _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return addedTask.Entity.Id;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            var tasksDto = await _context.Tasks.Where(t => !t.IsDeleted).ToListAsync();

            return _mapper.Map<List<TaskModel>>(tasksDto);
        }

        public async Task<TaskModel> GetTaskById(Guid id)
        {
            var task = await _context.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<TaskModel>(task);
        }

        public async Task<List<TaskModel>> GetTasksByProjectId(Guid id)
        {
            var tasks = await _context.Tasks
                .Where(t => t.Project.Id == id)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<TaskModel>>(tasks);
        }

        public async Task UpdateTask(TaskModel taskModel)
        {
            var task = _mapper.Map<Entities.Task>(taskModel);
            _context.Update(task);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(TaskModel taskModel)
        {
            var taskt = _mapper.Map<Entities.Task>(taskModel);

            _context.Entry(new Entities.Task { Id = taskt.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}
