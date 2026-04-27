using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCastController : Controller
    {
        public IActionResult CastList()
        {
            return View();
        }
    }
}
