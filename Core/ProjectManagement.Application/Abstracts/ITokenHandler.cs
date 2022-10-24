using ProjectManagement.Application.Dtos;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Abstracts
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(User user);
        string CreateRefreshToken();
    }
}
