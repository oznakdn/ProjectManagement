namespace ProjectManagement.Application.Features.User.Commands.LoginRefreshUser
{
    public class LoginRefreshUserCommandResponse
    {
        public string NewAccessToken { get; set; }
        public string NewRefreshToken { get; set; }
        public bool IsSuccess { get; set; }=true;
        public string ResponseMessage { get; set; }


    }
}
