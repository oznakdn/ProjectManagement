using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Department.Commands.AddDepartment;
using ProjectManagement.Application.Features.Department.Commands.DeleteDepartment;
using ProjectManagement.Application.Features.Department.Commands.UpdateDepartment;
using ProjectManagement.Application.Features.Department.Queries.GetAllDepartments;
using ProjectManagement.Application.Features.Department.Queries.GetDepartmentByName;
using ProjectManagement.Domain.Enums;
using ProjectManagement.WebAPI.Customizations;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorize(Role.Admin)]
    //[Authorize(Roles ="Admin")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult>GetDepartments()
        {
            var response = await mediator.Send(new GetAllDepartmentsQueryRequest());
            return Ok(response.ToList());
        }

        [HttpGet("{DepartmentName}")]
        public async Task<IActionResult>GetDepartment(string DepartmentName)
        {
            var response = await mediator.Send(new GetDepartmentByNameQueryRequest(DepartmentName));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] AddDepartmentCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response.ResponseMessage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task <DeleteDepartmentCommandResponse> DeleteDepartment(string id)
        {
            var response = await mediator.Send(new DeleteDepartmentCommandRequest(id));
            return response;
        }
    }
}
