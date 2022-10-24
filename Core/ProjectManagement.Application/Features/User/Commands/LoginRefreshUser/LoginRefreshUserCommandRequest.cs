using MediatR;

namespace ProjectManagement.Application.Features.User.Commands.LoginRefreshUser
{
    public class LoginRefreshUserCommandRequest:IRequest<LoginRefreshUserCommandResponse>
    {
        public LoginRefreshUserCommandRequest(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; set; }
    }
}
