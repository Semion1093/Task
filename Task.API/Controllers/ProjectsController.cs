using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Task.API.Models;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;

namespace Task.API.Controllers
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
        public ActionResult AddProject([FromBody] ProjectInputModel project)
        {
            var projectId = _projectService.AddProject(_mapper.Map<ProjectModel>(project));

            return StatusCode(201, projectId);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get project by id")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<ProjectOutputModel> GetProjectById(int id)
        {
            var project = _mapper.Map<ProjectOutputModel>(_projectService.GetProjectById(id));

            return project;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all projects")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult<List<ProjectOutputModel>> GetAllProjects()
        {
            var projects = _mapper.Map<List<ProjectOutputModel>>(_projectService.GetAllProjects());

            return projects;
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update project")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public ActionResult UpdateProject([FromBody] ProjectUpdateModel project)
        {
            var projectModel = _mapper.Map<ProjectModel>(project);
            _projectService.UpdateProject(projectModel);

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete project")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public ActionResult DeleteProject([FromBody] ProjectUpdateModel project)
        {
            var projctModel = _mapper.Map<ProjectModel>(project);
            _projectService.DeleteProject(projctModel);

            return NoContent();
        }
    }
}
