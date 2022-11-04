namespace ProjectManagement.Application.Features.Project.Commands.AddProject
{
    public class AddProjectCommandResponse
    {
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
        public bool IsValid { get; set; } = true;
        public List<string> ErrorMessages { get; set; } = new List<string>();

    }
}
