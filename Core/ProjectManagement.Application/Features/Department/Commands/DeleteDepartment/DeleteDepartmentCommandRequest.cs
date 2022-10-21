using MediatR;

namespace ProjectManagement.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandRequest:IRequest<DeleteDepartmentCommandResponse>
    {
        public DeleteDepartmentCommandRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
