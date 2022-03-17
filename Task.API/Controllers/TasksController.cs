using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Task.API.Models;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;

namespace Task.Controllers
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

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get task by id")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<TaskOutputModel> GetTaskById(int id)
        {
            var task = _mapper.Map<TaskOutputModel>(_taskService.GetTaskById(id));

            return task;
        }

        [HttpGet("by-project{id}")]
        [SwaggerOperation(Summary = "Get tasks by project id")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<List<TaskOutputModel>> GetTaskByProjectId(int id)
        {
            var tasks = _mapper.Map<List<TaskOutputModel>>(_taskService.GetTasksByProjectId(id));

            return tasks;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all tasks")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<List<TaskOutputModel>> GetAllTasks()
        {
            var tasks = _mapper.Map<List<TaskOutputModel>>(_taskService.GetAllTasks());

            return tasks;
        }


        [HttpPut]
        [SwaggerOperation(Summary = "Update task")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public ActionResult UpdateTask([FromBody] TaskUpdateModel task)
        {
            var taskModel = _mapper.Map<TaskModel>(task);
            _taskService.UpdateTask(taskModel);

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete task")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public ActionResult DeleteTask([FromBody] TaskUpdateModel task)
        {
            var taskModel = _mapper.Map<TaskModel>(task);
            _taskService.DeleteTask(taskModel);

            return NoContent();
        }
    }
}