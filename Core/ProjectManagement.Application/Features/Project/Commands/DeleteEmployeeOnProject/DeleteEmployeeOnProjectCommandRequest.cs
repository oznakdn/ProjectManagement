using MediatR;

namespace ProjectManagement.Application.Features.Project.Commands.DeleteEmployeeOnProject
{
    public class DeleteEmployeeOnProjectCommandRequest:IRequest<DeleteEmployeeOnProjectCommandResponse>
    {
        public string ProjectId { get; set; }
        public string EmployeeId { get; set; }

    }
}
