namespace ProjectManagement.Application.Features.User.Commands.LoginUser
{
    public class LoginUserCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; } = true;

    }
}
