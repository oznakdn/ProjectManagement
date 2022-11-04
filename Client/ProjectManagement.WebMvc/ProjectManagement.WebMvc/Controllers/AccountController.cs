using Microsoft.AspNetCore.Mvc;
using ProjectManagement.WebMvc.ClientServices.Contracts;
using ProjectManagement.WebMvc.Models.UserViewModels;

namespace ProjectManagement.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAccountService accountService;

        public AccountController(IConfiguration configuration, IAccountService accountService)
        {
            this.configuration = configuration;
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {

            /*
             
            HttpClient client = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonConvert.SerializeObject(login);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:7122/api/Account/Login", contentData);

            string stringJwt = await response.Content.ReadAsStringAsync();

            JwtTokenModel token = JsonConvert.DeserializeObject<JwtTokenModel>(stringJwt);

            HttpContext.Session.SetString("accessToken", token.AccessToken);
             
             */


            var token =await accountService.Login(login);
            HttpContext.Session.SetString("accessToken", token.AccessToken);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("accessToken");
            ViewBag.Message = "User logged out successfully!";
            return RedirectToAction(nameof(Login));
        }
    }
}
