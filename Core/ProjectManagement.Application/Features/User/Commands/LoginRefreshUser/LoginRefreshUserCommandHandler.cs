using MediatR;
using ProjectManagement.Application.Abstracts;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.LoginRefreshUser
{
    public class LoginRefreshUserCommandHandler : IRequestHandler<LoginRefreshUserCommandRequest, LoginRefreshUserCommandResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly ICommandUnitOfWork command;
        private readonly ITokenHandler tokenHandler;

        public LoginRefreshUserCommandHandler(IQueryUnitOfWork query, ICommandUnitOfWork command, ITokenHandler tokenHandler)
        {
            this.query = query;
            this.command = command;
            this.tokenHandler = tokenHandler;
        }

        public async Task<LoginRefreshUserCommandResponse> Handle(LoginRefreshUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await query.UserQuery.GetAsync(u => u.RefreshToken == request.RefreshToken);
            if (user != null && user.RefreshTokenExpireTime > DateTime.Now)
            {
                var token = tokenHandler.CreateAccessToken(user);
                user.RefreshTokenExpireTime = DateTime.Now.AddMinutes(10);
                user.RefreshToken = token.RefreshToken;
                command.UserCommand.Update(user);
                await command.SaveAsync();

                return new LoginRefreshUserCommandResponse
                {
                    IsSuccess = true,
                    NewAccessToken = token.AccessToken,
                    NewRefreshToken = token.RefreshToken,
                    ResponseMessage = "Success"
                };
            }
            return new LoginRefreshUserCommandResponse
            {
                IsSuccess = false,
                NewAccessToken = String.Empty,
                NewRefreshToken = String.Empty,
                ResponseMessage = "User is not exists or refresh token is wrong!"
            };
        }
    }
}
