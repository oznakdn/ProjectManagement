using MediatR;

namespace ProjectManagement.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandRequest:IRequest<AddDepartmentCommandResponse>
    {
        public string DepartmentName { get; set; }

    }
}
