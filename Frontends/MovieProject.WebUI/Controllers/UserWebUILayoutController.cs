using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.Controllers
{
    public class UserWebUILayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
