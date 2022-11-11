using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging;
using ProjectManagement.WebMvc.Helpers;
using ProjectManagement.WebMvc.Models.DepartmentViewModels;
using System.Net.Http.Json;

namespace ProjectManagement.WebMvc.Controllers
{
    public class DepartmentController : Controller
    {

        public async Task<IActionResult> Index()
        {

            //var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(contentType);

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("accessToken"));

            var client = TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);

            HttpResponseMessage response = await client.GetAsync("https://localhost:7122/api/Departments");
            string stringData = await response.Content.ReadAsStringAsync();


            List<GetDepartmentsViewModel> departments = JsonConvert.DeserializeObject<List<GetDepartmentsViewModel>>(stringData);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ViewBag.message = "Unauthorized Person";
                return PartialView("_UnauthorizePartialView");
            }

            return View(departments);
        }

        public async Task<IActionResult>Details(string departmentName)
        {
            var client = TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);
            var response = await client.GetFromJsonAsync<GetDepartmentsViewModel>($"https://localhost:7122/api/Departments/{departmentName}");

            return View(response);
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

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(createDepartment);
            }

            return View(createDepartment);
        }

      
        public async Task<IActionResult> Edit(string departmentName)
        {
            var client = TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);
            var response =await client.GetFromJsonAsync<UpdateDepartmentViewModel>($"https://localhost:7122/api/Departments/{departmentName}");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDepartmentViewModel updateDepartment)
        {
            var client = TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);
            var response = await client.PutAsJsonAsync("https://localhost:7122/api/Departments", updateDepartment);
            if(ModelState.IsValid)
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(updateDepartment);

            }

            return View(updateDepartment);


        }

        public async Task<IActionResult> Delete(string id)
        {
            var client = TokenSavingSessionHelper.TokenSaveOnSession(HttpContext);
            var response = await client.DeleteAsync($"https://localhost:7122/api/Departments/{id}");
            return RedirectToAction(nameof(Index));
        }
    }

}
