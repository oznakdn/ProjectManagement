using MediatR;

namespace ProjectManagement.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandRequest:IRequest<UpdateDepartmentCommandResponse>
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }

    }
}
