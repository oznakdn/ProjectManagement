using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectManagement.WebMvc.Models.DepartmentViewModels;
using System.Net.Http.Headers;

namespace ProjectManagement.WebMvc.Controllers
{
    public class DepartmentController : Controller
    {


        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("accessToken"));

            HttpResponseMessage respponse =await client.GetAsync("https://localhost:7122/api/Departments");
            string stringData =await respponse.Content.ReadAsStringAsync();

            List<GetDepartmentsViewModel> departments = JsonConvert.DeserializeObject<List<GetDepartmentsViewModel>>(stringData);
            if (respponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ViewBag.message = "Unauthorized Person";
                return PartialView("_UnauthorizePartialView");
            }
                
            return View(departments);
        }
    }
}
