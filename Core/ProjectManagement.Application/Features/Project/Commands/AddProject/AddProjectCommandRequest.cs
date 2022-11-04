using MediatR;

namespace ProjectManagement.Application.Features.Project.Commands.AddProject
{
    public class AddProjectCommandRequest:IRequest<AddProjectCommandResponse>
    {
        public string ProjectTitle { get; set; }
        public string ProjectDetails { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}
