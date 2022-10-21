using MediatR;
using ProjectManagement.Domain.Enums;

namespace ProjectManagement.Application.Features.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandRequest:IRequest<UpdateUserRoleCommandResponse>
    {
        public UpdateUserRoleCommandRequest(string id, Role role)
        {
            Id = id;
            Role = role;
        }
        public string Id { get; set; }
        public Role Role { get; set; }
    }
}
