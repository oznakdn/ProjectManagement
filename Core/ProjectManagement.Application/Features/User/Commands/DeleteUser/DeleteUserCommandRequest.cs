using MediatR;

namespace ProjectManagement.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandRequest:IRequest<DeleteUserCommandResponse>
    {
        public DeleteUserCommandRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
