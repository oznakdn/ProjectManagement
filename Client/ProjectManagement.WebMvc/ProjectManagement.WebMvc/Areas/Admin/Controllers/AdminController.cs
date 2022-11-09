using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.WebMvc.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
