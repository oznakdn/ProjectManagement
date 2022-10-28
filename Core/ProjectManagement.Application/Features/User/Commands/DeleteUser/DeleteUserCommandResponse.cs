namespace ProjectManagement.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandResponse
    {
        public DeleteUserCommandResponse(bool isSuccess,string responseMessage)
        {
            ResponseMessage = responseMessage;
            IsSuccess = isSuccess;
        }
        public bool IsSuccess { get; set; }
        public string ResponseMessage { get; set; }
    }
}
