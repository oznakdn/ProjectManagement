using MediatR;

namespace ProjectManagement.Application.Features.User.Commands.AddEmployeeToUser
{
    public class AddEmployeeToUserCommandRequest:IRequest<AddEmployeeToUserCommandResponse>
    {
        public AddEmployeeToUserCommandRequest(string userId, string employeeId)
        {
            UserId = userId;
            EmployeeId = employeeId;
        }

        public string UserId { get; set; }
        public string EmployeeId { get; set; }
    }
}
