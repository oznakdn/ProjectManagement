using MediatR;
using Microsoft.Extensions.Configuration;
using ProjectManagement.Application.Abstracts;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly ICommandUnitOfWork command;
        private readonly ITokenHandler tokenHandler;
        private IConfiguration configuration;

        public LoginUserCommandHandler(IQueryUnitOfWork query, IConfiguration configuration, ITokenHandler tokenHandler, ICommandUnitOfWork command)
        {
            this.query = query;
            this.configuration = configuration;
            this.tokenHandler = tokenHandler;
            this.command = command;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var hashedPassword = PasswordGeneratorExtension.PasswordHashGenerate(configuration, request.Password);
            var user = await query.UserQuery.GetAsync(u => u.Username == request.Username && u.Password == hashedPassword);

            if (user == null)
            {
                return new LoginUserCommandResponse
                {
                    IsSuccess = false,
                    AccessToken = String.Empty,
                    RefreshToken = String.Empty,
                    ResponseMessage = "Username or Password is wrong!"
                };
            }

            var token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireTime = DateTime.Now.AddMinutes(10);
            command.UserCommand.Update(user);
            await command.SaveAsync();


            return new LoginUserCommandResponse
            {
                IsSuccess = true,
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken

            };


        }
    }
}
