using MediatR;

namespace ProjectManagement.Application.Features.Project.Commands.AddProjectEmployee
{
    public class AddProjectEmployeeCommandRequest:IRequest<AddProjectEmployeeCommandResponse>
    {
       
        public string ProjectId { get; set; }
        public string EmployeeId { get; set; }

    }
}
