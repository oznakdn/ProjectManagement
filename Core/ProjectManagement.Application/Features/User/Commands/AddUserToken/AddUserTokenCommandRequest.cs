using MediatR;

namespace ProjectManagement.Application.Features.User.Commands.AddUserToken
{
    public class AddUserTokenCommandRequest:IRequest<AddUserTokenCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
