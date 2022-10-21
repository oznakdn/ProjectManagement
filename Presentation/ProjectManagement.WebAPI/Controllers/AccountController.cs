using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.User.Commands.AddUser;
using ProjectManagement.Application.Features.User.Commands.AddUserToken;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            if(response.IsSuccess)
            {
                return Ok(response.ResponseMessage);

            }
            return BadRequest(response.ResponseMessage);
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
