using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.User.Queries.GetAllUsers;
using ProjectManagement.Application.Features.User.Queries.GetUserDetails;
using ProjectManagement.Domain.Enums;
using ProjectManagement.WebAPI.Customizations;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[CustomAuthorize(Role.Manager,Role.Admin)]

    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetail(string id)
        {
            var response = await mediator.Send(new GetUserDetailsQueryRequest(id));
            
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult>GetUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());
            if(response.Count == 0)
            {
                return BadRequest("There is no any user.");
            }

            return Ok(response);
        }


    }
}
