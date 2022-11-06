using MediatR;

namespace ProjectManagement.Application.Features.User.Commands.LogoutUser
{
    public class LogoutUserCommandRequest:IRequest<LogoutUserCommandResponse>
    {
        public LogoutUserCommandRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
