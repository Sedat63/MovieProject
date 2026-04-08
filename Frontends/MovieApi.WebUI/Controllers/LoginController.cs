using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
