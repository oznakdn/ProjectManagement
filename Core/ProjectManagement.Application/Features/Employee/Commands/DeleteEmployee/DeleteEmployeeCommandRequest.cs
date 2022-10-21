using MediatR;

namespace ProjectManagement.Application.Features.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandRequest:IRequest<DeleteEmployeeCommandResponse>
    {
        public DeleteEmployeeCommandRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
