using MediatR;

namespace ProjectManagement.Application.Features.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandRequest:IRequest<UpdateProjectCommandResponse>
    {

        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDetails { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }

    }
}
