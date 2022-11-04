using ProjectManagement.WebMvc.Models.UserViewModels;

namespace ProjectManagement.WebMvc.ClientServices.Contracts
{
    public interface IAccountService
    {
        Task<JwtTokenModel> Login(LoginViewModel login);
    }
}
