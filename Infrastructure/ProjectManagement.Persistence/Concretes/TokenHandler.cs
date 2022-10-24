using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Application.Abstracts;
using ProjectManagement.Application.Dtos;
using ProjectManagement.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProjectManagement.Persistence.Concretes
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TokenDto CreateAccessToken(User user)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = configuration.GetValue<string>("Jwt:Audience"),
                Issuer = configuration.GetValue<string>("Jwt:Issuer"),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                Expires = DateTime.Now.AddMinutes(5),
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role.ToString())

                }),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = CreateRefreshToken()
            };

        }

        public string CreateRefreshToken()
        {
            var numbers = new byte[32];
            using RandomNumberGenerator randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(numbers);
            return Convert.ToBase64String(numbers);
               
        }
    }

}

