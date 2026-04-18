using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutBreadCrumbComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
