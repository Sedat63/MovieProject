using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.Models.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUIHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
