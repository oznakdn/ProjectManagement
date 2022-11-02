using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Project.Commands.AddProjectEmployee
{
    public class AddProjectEmployeeCommandHandler : IRequestHandler<AddProjectEmployeeCommandRequest, AddProjectEmployeeCommandResponse>
    {
        private readonly ICommandUnitOfWork command;

        public AddProjectEmployeeCommandHandler(ICommandUnitOfWork command)
        {
            this.command = command;
        }

        public async Task<AddProjectEmployeeCommandResponse> Handle(AddProjectEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var isSaved = 0;
            await command.ProjectCommand.AddProjectEmployee(request.ProjectId, request.EmployeeId);
            isSaved = await command.SaveAsync();

            if(isSaved >0)
            return new AddProjectEmployeeCommandResponse { IsSuccess = true, ResponseMessage="Employee was added on the project." };

            return new AddProjectEmployeeCommandResponse { IsSuccess = false, ResponseMessage = "Can not be added!" };
        }
    }
}
