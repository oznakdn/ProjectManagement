namespace ProjectManagement.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandResponse
    {
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages = new();
    }
}
