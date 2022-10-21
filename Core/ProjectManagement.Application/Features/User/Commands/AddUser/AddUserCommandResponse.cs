namespace ProjectManagement.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandResponse
    {
        public AddUserCommandResponse(string responseMessage)
        {
            ResponseMessage = responseMessage;
            IsSuccess = true;
        }

        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
