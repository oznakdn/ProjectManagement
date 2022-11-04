namespace ProjectManagement.Application.Features.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandResponse
    {
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
        public bool IsValid { get; set; } = true;
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
