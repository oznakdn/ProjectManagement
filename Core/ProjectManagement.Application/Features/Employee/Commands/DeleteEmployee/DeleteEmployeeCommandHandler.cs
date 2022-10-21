using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;


        public DeleteEmployeeCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query)
        {
            this.command = command;
            this.query = query;
        }

        public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = await query.EmployeeQuery.GetByIdAsync(request.Id);
            if (employee == null) return new DeleteEmployeeCommandResponse($"{request.Id} employee is not found!");

            command.EmployeeCommand.Remove(employee);
            await command.SaveAsync();
            return new DeleteEmployeeCommandResponse($"{request.Id} employee is deleted successfully.");
        }
    }
}
