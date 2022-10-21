using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Application.Validations.EmployeeValidators;

namespace ProjectManagement.Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public UpdateEmployeeCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query, IMapper mapper)
        {
            this.command = command;
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEmployeeValidator();
            var messages = new List<string>();
            var response = new UpdateEmployeeCommandResponse();
            var existEmployee = await query.EmployeeQuery.GetByIdAsync(request.Id);
            if(existEmployee == null)
            {
                response.ResponseMessages.Add("Employee not found!");
            }

            var employee = mapper.Map(request, existEmployee);
          
            var validationResult = validator.Validate(request);
            if(validationResult.IsValid)
            {
                response.IsValid = true;
                command.EmployeeCommand.Update(employee);
                await command.SaveAsync();
                messages.Add("Employee is updated successfully.");
                response.ResponseMessages = messages;
            }
            else
            {
                response.IsValid = false;
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
