using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Application.Validations.EmployeeValidators;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Features.Employee.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public AddEmployeeCommandHandler(ICommandUnitOfWork command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new AddEmployeeValidator();
            var response = new AddEmployeeCommandResponse();
            var messages = new List<string>();

            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var employee = mapper.Map<Domain.Entities.Employee>(request);
                await command.EmployeeCommand.AddAsync(employee);
                await command.SaveAsync();
                response.IsValid= true;
                messages.Add("Employee is added successfully.");
                response.ResponseMessages = messages;
            }
            else
            {
                response.IsValid= false;
                foreach (var error in validationResult.Errors)
                {
                    messages.Add(error.ErrorMessage);
                }
                response.ResponseMessages = messages;
            }
            return response;

           
        }
    }
}
