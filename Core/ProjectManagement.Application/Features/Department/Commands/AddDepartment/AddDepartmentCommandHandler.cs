using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Application.Validations.DepartmentValidators;

namespace ProjectManagement.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommandRequest, AddDepartmentCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public AddDepartmentCommandHandler(ICommandUnitOfWork command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<AddDepartmentCommandResponse> Handle(AddDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AddDepartmentCommandResponse();
            var validator = new AddDepartmentValidator();
            var validationResult = validator.Validate(request);

            if(validationResult.IsValid)
            {
                var department = mapper.Map<Domain.Entities.Department>(request);
                await command.DepartmentCommand.AddAsync(department);
                await command.SaveAsync();
                response.ResponseMessage = "Department was created successfully.";
                response.IsSuccess = true;
                response.ErrorMessages = null;
            }
            else
            {
                response.IsSuccess = false;
                foreach (var item in validationResult.Errors)
                {
                    response.ErrorMessages.Add(item.ErrorMessage);
                }
            }

            return response;
            
            
        }
    }
}
