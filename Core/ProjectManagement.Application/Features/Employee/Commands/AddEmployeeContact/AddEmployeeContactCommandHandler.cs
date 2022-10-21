using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Features.Employee.Commands.AddEmployeeContact
{
    public class AddEmployeeContactCommandHandler : IRequestHandler<AddEmployeeContactCommandRequest, AddEmployeeContactCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;

        public AddEmployeeContactCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query)
        {
            this.command = command;
            this.query = query;
        }

        public async Task<AddEmployeeContactCommandResponse> Handle(AddEmployeeContactCommandRequest request, CancellationToken cancellationToken)
        {

            await command.EmployeeCommand.AddEmployeeContact(request.EmployeeId, new Contact
            {
                Id = Guid.Parse(request.EmployeeId),
                Address = request.Address,
                City = request.City,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
            });
            await command.SaveAsync();
            return new AddEmployeeContactCommandResponse("Employee contact is added successfully.");
        }
    }
}
