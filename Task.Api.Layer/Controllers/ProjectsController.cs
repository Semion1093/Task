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
    public class ProjectsController : Controller
    {
        private IProjectService _projectService;
        private IMapper _mapper;

        public ProjectsController(IProjectService projectsService, IMapper mapper)
        {
            _projectService = projectsService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new project")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult> AddProject([FromBody] ProjectInputModel project)
        {
            var projectId = await _projectService.AddProject( _mapper.Map<ProjectModel>(project));

            return StatusCode(201, projectId);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get project by id")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<ProjectOutputModel>> GetProjectById(Guid id)
        {
            var project = _mapper.Map<ProjectOutputModel>(await _projectService.GetProjectById(id));

            return project;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all projects")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<ProjectOutputModel>>> GetAllProjects()
        {
            var projects = _mapper.Map<List<ProjectOutputModel>>(await _projectService.GetAllProjects());

            return projects;
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update project")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> UpdateProject([FromBody] ProjectUpdateModel project)
        {
            var projectModel = _mapper.Map<ProjectModel>(project);
            await _projectService.UpdateProject(projectModel);

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete project")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> DeleteProject([FromBody] ProjectUpdateModel project)
        {
            var projctModel = _mapper.Map<ProjectModel>(project);
            await _projectService.DeleteProject(projctModel);

            return NoContent();
        }
    }
}
