using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Application.Validations.ProjectValidators;

namespace ProjectManagement.Application.Features.Project.Commands.AddProject
{
    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommandRequest, AddProjectCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public AddProjectCommandHandler(ICommandUnitOfWork command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<AddProjectCommandResponse> Handle(AddProjectCommandRequest request, CancellationToken cancellationToken)
        {
            var validator =new AddProjectValidator();
            var validationResult = validator.Validate(request);
            var response = new AddProjectCommandResponse();

            if(validationResult.IsValid)
            {
                var project = mapper.Map<ProjectManagement.Domain.Entities.Project>(request);
                await command.ProjectCommand.AddAsync(project);
                await command.SaveAsync();
                response.IsValid = true;
                response.IsSuccess = true;
                response.ErrorMessages = null;
                response.ResponseMessage = "Project was created successfully.";
            }
            else
            {
                response.IsValid = false;
                response.IsSuccess = false;
                response.ResponseMessage = "Project could not created!";
                foreach (var item in validationResult.Errors)
                {
                    response.ErrorMessages.Add(item.ErrorMessage);
                }
            }
            return response;

        }
    }
}
