using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.User.Commands.AddUser;
using ProjectManagement.Application.Features.User.Commands.LoginRefreshUser;
using ProjectManagement.Application.Features.User.Commands.LoginUser;
using ProjectManagement.Application.Features.User.Commands.LogoutUser;
using System.Security.Claims;

namespace ProjectManagement.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AddUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok(response.ResponseMessage);

            }
            return BadRequest(response.ResponseMessage);
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.ResponseMessage);
        }

        [HttpPost("{refreshToken}")]
        public async Task<IActionResult> LoginRefresh(string refreshToken)
        {
            var response = await mediator.Send(new LoginRefreshUserCommandRequest(refreshToken));
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.ResponseMessage);

        }


        // TODO: Logout endpoint yapılacak
        //[Authorize(Roles ="Admin")]
        [HttpPost("{userId}")]
        public async Task<IActionResult> Logout(string userId)
        {
            string id = HttpContext.User.FindFirstValue(userId);
            if(userId == null)
            {
                return Unauthorized();
            }

            var response =await mediator.Send(new LogoutUserCommandRequest (userId));
            if (response.IsSuccess)
                return Ok(response.ResponseMessage);

            return BadRequest(response.ResponseMessage);

        }
    }
}
