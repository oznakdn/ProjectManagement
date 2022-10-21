namespace ProjectManagement.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandResponse
    {
        public AddDepartmentCommandResponse(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
