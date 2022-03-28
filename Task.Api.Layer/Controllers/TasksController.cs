using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestTask.API.Layer.Models;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;

namespace TestTask.API.Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private ITaskService _taskService;
        private IMapper _mapper;

        public TasksController(ITaskService tasksService, IMapper mapper)
        {
            _taskService = tasksService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new task")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult> AddTask([FromBody] TaskInsertModel task)
        {
            var taskId = await _taskService.AddTask(_mapper.Map<TaskModel>(task));

            return StatusCode(201, taskId);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get task by id")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<TaskOutputModel>> GetTaskById(Guid id)
        {
            var task = _mapper.Map<TaskOutputModel>(await _taskService.GetTaskById(id));

            return task;
        }

        [HttpGet("by-project{id}")]
        [SwaggerOperation(Summary = "Get tasks by project id")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<TaskOutputModel>>> GetTaskByProjectId(Guid id)
        {
            var tasks = _mapper.Map<List<TaskOutputModel>>(await _taskService.GetTasksByProjectId(id));

            return tasks;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all tasks")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<TaskOutputModel>>> GetAllTasks()
        {
            var tasks = _mapper.Map<List<TaskOutputModel>>(await _taskService.GetAllTasks());

            return tasks;
        }


        [HttpPut]
        [SwaggerOperation(Summary = "Update task")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> UpdateTask([FromBody] TaskUpdateModel task)
        {
            var taskModel = _mapper.Map<TaskModel>(task);
            await _taskService.UpdateTask(taskModel);

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete task")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> DeleteTask([FromBody] TaskUpdateModel task)
        {
            var taskModel = _mapper.Map<TaskModel>(task);
            await _taskService.DeleteTask(taskModel);

            return NoContent();
        }
    }
}