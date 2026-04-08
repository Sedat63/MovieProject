using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
