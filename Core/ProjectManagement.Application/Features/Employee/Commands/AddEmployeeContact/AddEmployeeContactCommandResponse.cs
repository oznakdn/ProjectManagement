namespace ProjectManagement.Application.Features.Employee.Commands.AddEmployeeContact
{
    public class AddEmployeeContactCommandResponse
    {
        public AddEmployeeContactCommandResponse(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
