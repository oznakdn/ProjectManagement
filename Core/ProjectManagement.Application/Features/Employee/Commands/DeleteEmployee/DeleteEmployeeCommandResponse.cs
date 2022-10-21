namespace ProjectManagement.Application.Features.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandResponse
    {
        public DeleteEmployeeCommandResponse(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
