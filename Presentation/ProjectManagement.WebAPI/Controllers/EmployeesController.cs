using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Employee.Commands.AddEmployee;
using ProjectManagement.Application.Features.Employee.Commands.AddEmployeeContact;
using ProjectManagement.Application.Features.Employee.Commands.DeleteEmployee;
using ProjectManagement.Application.Features.Employee.Commands.UpdateEmployee;
using ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesByDepartment;
using ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesWith;
using ProjectManagement.Application.Features.Employee.Queries.GetEmployeeById;
using ProjectManagement.Application.Features.Employee.Queries.GetEmployeeWith;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //protected IMediator Mediator => _mediator ??=HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var response = await _mediator.Send(new GetAllEmployeesWithQueryRequest());
            var result = response.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EmployeesByDepartmentId(string id)
        {
            var employee = await _mediator.Send(new GetAllEmployeesByDepartmentQueryRequest(id));
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EmployeeDetails(string id)
        {
            var employee = await _mediator.Send(new GetEmployeeWithQueryRequest(id));
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAdd([FromBody] AddEmployeeCommandRequest request)
        {

            var response = await _mediator.Send(request);
            if (response.IsValid)
            {
                return Ok(response.ResponseMessages.FirstOrDefault());

            }
            return BadRequest(response.ResponseMessages);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAddContact([FromBody] AddEmployeeContactCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response.ResponseMessage);
        }

        [HttpPut]
        public async Task<IActionResult> EmployeeUpdate([FromBody] UpdateEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if(response.IsValid)
            {
                return Ok(response.ResponseMessages);
            }

            return BadRequest(response.ResponseMessages);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EmployeeDelete(string id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommandRequest(id));
            return Ok(response.ResponseMessage);
        }


    }
}
