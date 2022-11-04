using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Project.Commands.AddProject;
using ProjectManagement.Application.Features.Project.Commands.AddProjectEmployee;
using ProjectManagement.Application.Features.Project.Commands.DeleteEmployeeOnProject;
using ProjectManagement.Application.Features.Project.Commands.UpdateProject;
using ProjectManagement.Application.Features.Project.Queries.GetAllProjects;
using ProjectManagement.Application.Features.Project.Queries.GetAllProjectsWith;
using ProjectManagement.Application.Features.Project.Queries.GetProjectById;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProjectsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("Projects")]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetAllProjectsQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ActionName("Project")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await mediator.Send(new GetProjectByIdQueryRequest(id));
            if (response == null)
                return NotFound(response.ResponseMessage);

            return Ok(response);
        }

        [HttpGet]
        [ActionName("ProjectsWithEmployee")]
        public async Task<IActionResult> GetProjectsWithEmployee()
        {
            var response = await mediator.Send(new GetAllProjectsWithQueryRequest());
            return Ok(response);
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject([FromBody] AddProjectCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccess)
                return Ok(response.ResponseMessage);

            return BadRequest(new {response.ResponseMessage , response.ErrorMessages});
        }

        [HttpPost]
        [ActionName("AddProjectEmployee")]
        public async Task<IActionResult> AddProjectEmployee([FromBody] AddProjectEmployeeCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccess)
                return Ok(response.ResponseMessage);

            return BadRequest(response.ResponseMessage);
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccess)
                return Ok(response.ResponseMessage);

            return BadRequest(new { response.ResponseMessage, response.ErrorMessages });
        }

        [HttpDelete]
        [ActionName("DeleteProjectOnEmployee")]
        public async Task<IActionResult> Delete([FromBody] DeleteEmployeeOnProjectCommandRequest request)
        {
            var response =await mediator.Send(request);
            if (response.IsSuccess)
                return Ok(response.ResponseMessage);

            return BadRequest(response.ResponseMessage);
        }

       
    }
}
