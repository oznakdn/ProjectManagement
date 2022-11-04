using Newtonsoft.Json;
using ProjectManagement.WebMvc.ClientServices.Contracts;
using ProjectManagement.WebMvc.Models.UserViewModels;
using System.Net.Http.Headers;
using System.Text;


namespace ProjectManagement.WebMvc.ClientServices.Concretes
{
    public class AccountService: IAccountService
    {
        public async Task<JwtTokenModel> Login(LoginViewModel login)
        {
            HttpClient client = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonConvert.SerializeObject(login);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:7122/api/Account/Login", contentData);

            string stringJwt = await response.Content.ReadAsStringAsync();

            JwtTokenModel token = JsonConvert.DeserializeObject<JwtTokenModel>(stringJwt);

            
            return new JwtTokenModel
            {
                 AccessToken = token.AccessToken,
                 RefreshToken = token.RefreshToken
            };


        }
    }
}
