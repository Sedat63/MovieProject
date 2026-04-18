using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
