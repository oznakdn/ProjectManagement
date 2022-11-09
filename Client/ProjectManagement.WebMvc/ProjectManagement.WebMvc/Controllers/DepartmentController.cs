using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectManagement.WebMvc.Helpers;
using ProjectManagement.WebMvc.Models.DepartmentViewModels;

namespace ProjectManagement.WebMvc.Controllers
{
    public class DepartmentController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
           
            //var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(contentType);

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("accessToken"));

            var client =TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);

            HttpResponseMessage response =await client.GetAsync("https://localhost:7122/api/Departments");
            string stringData =await response.Content.ReadAsStringAsync();


            List<GetDepartmentsViewModel> departments = JsonConvert.DeserializeObject<List<GetDepartmentsViewModel>>(stringData);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ViewBag.message = "Unauthorized Person";
                return PartialView("_UnauthorizePartialView");
            }
                
            return View(departments);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentViewModel createDepartment)
        {
            HttpResponseMessage response;
            if (ModelState.IsValid)
            {
                var client = TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);
                response = await client.PostAsJsonAsync("https://localhost:7122/api/Departments", createDepartment);

                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(createDepartment);
            }

            return View(createDepartment);
        }
    }

}
