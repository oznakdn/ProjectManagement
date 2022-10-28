using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.User.Commands.AddEmployeeToUser;
using ProjectManagement.Application.Features.User.Commands.DeleteUser;
using ProjectManagement.Application.Features.User.Commands.UpdateUserRole;
using ProjectManagement.Application.Features.User.Queries.GetAllUsers;
using ProjectManagement.Application.Features.User.Queries.GetUserDetails;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[CustomAuthorize(Role.Manager,Role.Admin)]

    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());
            if (response.Count == 0)
            {
                return BadRequest("There is no any user.");
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetail(string id)
        {
            var response = await mediator.Send(new GetUserDetailsQueryRequest(id));
            if(!response.IsSuccess)
            {
                return NotFound(response.ResponseMessage);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditUserRole([FromBody] UpdateUserRoleCommandRequest request)
        {
            var response = await mediator.Send(new UpdateUserRoleCommandRequest(request.Id,request.Role));
            if(response.IsSuccess)
            {
                return Ok(response.ResponseMessage);
            }
            return BadRequest(response.ResponseMessage);
        }

        [HttpPut]
        public async Task<IActionResult> AddEmployeeToUser([FromBody] AddEmployeeToUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok(response.ResponseMessage);
            }
            return BadRequest(response.ResponseMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUser(string id)
        {
            var response = await mediator.Send(new DeleteUserCommandRequest(id));
            if (response.IsSuccess)
                return Ok(response.ResponseMessage);

            return BadRequest(response.ResponseMessage);
        }



    }
}
