using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.Application.Features.User.Commands.AddUserToken
{
    public class AddUserTokenCommandHandler : IRequestHandler<AddUserTokenCommandRequest, AddUserTokenCommandResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IConfiguration configuration;

        public AddUserTokenCommandHandler(IQueryUnitOfWork query, IConfiguration configuration)
        {
            this.query = query;
            this.configuration = configuration;
        }

        public async Task<AddUserTokenCommandResponse> Handle(AddUserTokenCommandRequest request, CancellationToken cancellationToken)
        {
            // Username and Password validation check
            request.Password = PasswordGeneratorExtension.PasswordHashGenerate(configuration, request.Password);

            var existsUser = await query.UserQuery.AnyAsync(u => u.Username ==
            request.Username && u.Password == request.Password);

            var user = await query.UserQuery.GetAsync(u => u.Username == request.Username && u.Password == request.Password);

            // Username or/and password invalid check
            if (!existsUser || user == null)
            {
                return new AddUserTokenCommandResponse { ResponseMessage = "Username or Password is wrong!", Token = string.Empty,IsSuccess=false };
            }

            // If User is exists ,creating a token 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signingCredentals = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration.GetValue<string>("Jwt:Issuer"),
                Audience = configuration.GetValue<string>("Jwt:Audience"),
                SigningCredentials = signingCredentals,
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim (ClaimTypes.Name,user.Username),
                        new Claim (ClaimTypes.Role,user.Role.ToString()),
                    }
                ),
                Expires = DateTime.Now.AddMinutes(5)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            // returns access token

            return new AddUserTokenCommandResponse { Token = accessToken, ResponseMessage = "Token is created successfully",IsSuccess = true };

        }
    }
}
