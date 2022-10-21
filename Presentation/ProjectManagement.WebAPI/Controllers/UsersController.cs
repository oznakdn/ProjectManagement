using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.User.Commands.AddUser;
using ProjectManagement.Application.Features.User.Commands.AddUserToken;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AddUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response.ResponseMessage);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AddUserTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            if(string.IsNullOrEmpty(response.Token))
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
