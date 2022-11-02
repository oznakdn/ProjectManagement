using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Project.Commands.DeleteEmployeeOnProject
{
    public class DeleteEmployeeOnProjectCommandHandler : IRequestHandler<DeleteEmployeeOnProjectCommandRequest, DeleteEmployeeOnProjectCommandResponse>
    {
        private readonly ICommandUnitOfWork command;

        public DeleteEmployeeOnProjectCommandHandler(ICommandUnitOfWork command)
        {
            this.command = command;
        }

        public async Task<DeleteEmployeeOnProjectCommandResponse> Handle(DeleteEmployeeOnProjectCommandRequest request, CancellationToken cancellationToken)
        {
            int isSaved = 0;

            await command.ProjectCommand.DeleteEmployeeOnProject(request.ProjectId, request.EmployeeId);
            isSaved = await command.SaveAsync();
            if (isSaved > 0)
                return new DeleteEmployeeOnProjectCommandResponse { IsSuccess = true, ResponseMessage = "Employee was deleted on the project." };

            return new DeleteEmployeeOnProjectCommandResponse {IsSuccess=false, ResponseMessage = "Could not be deleted" };
        }
    }
}
