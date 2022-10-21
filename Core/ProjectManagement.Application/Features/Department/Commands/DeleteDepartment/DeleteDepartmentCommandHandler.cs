using MediatR;
using Microsoft.AspNetCore.Http;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommandRequest, DeleteDepartmentCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;
        public DeleteDepartmentCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query)
        {
            this.command = command;
            this.query = query;
        }

        public async Task<DeleteDepartmentCommandResponse> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var department = await query.DepartmentQuery.GetByIdAsync(request.Id);
            if(department == null)
            {
                return new DeleteDepartmentCommandResponseMessage("Department is not found!") { StatusCode = StatusCodes.Status404NotFound };
            }

            command.DepartmentCommand.Remove(department);
            await command.SaveAsync();
            return new DeleteDepartmentCommandResponseMessage("Department is deleted successfully.") { StatusCode = StatusCodes.Status204NoContent};
        }
    }
}
