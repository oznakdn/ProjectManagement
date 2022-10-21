namespace ProjectManagement.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandResponse
    {
        public AddUserCommandResponse(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
