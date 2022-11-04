using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Application.Validations.ProjectValidators;

namespace ProjectManagement.Application.Features.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommandRequest, UpdateProjectCommandResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly ICommandUnitOfWork command;
        private readonly IMapper mapper;

        public UpdateProjectCommandHandler(IQueryUnitOfWork query, ICommandUnitOfWork command, IMapper mapper)
        {
            this.query = query;
            this.command = command;
            this.mapper = mapper;
        }

        public async Task<UpdateProjectCommandResponse> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateProjectCommandResponse();
            var validator = new UpdateProjectValidator();
            var validateResult = validator.Validate(request);

            if (validateResult.IsValid)
            {
                var existProject = await query.ProjectQuery.GetByIdAsync(request.Id);
                if(existProject == null)
                {
                    response.IsSuccess = false;
                    response.ResponseMessage = "Project not found!";
                }
                else
                {
                    var project = mapper.Map(request, existProject);
                    command.ProjectCommand.Update(project);
                    await command.SaveAsync();
                    response.IsValid = true;
                    response.IsSuccess = true;
                    response.ResponseMessage = "Project was updated successfully.";
                    response.ErrorMessages = null;
                }
                
            }
            else
            {
                response.IsSuccess = false;
                response.IsValid = false;
                response.ResponseMessage = "Project could not updated!";

                foreach (var item in validateResult.Errors)
                {
                    response.ErrorMessages.Add(item.ErrorMessage);
                }
            }

            return response;
        }
    }
}
