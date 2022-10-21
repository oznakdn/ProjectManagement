using MediatR;
using ProjectManagement.Domain.Enums;

namespace ProjectManagement.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandRequest:IRequest<AddUserCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}
