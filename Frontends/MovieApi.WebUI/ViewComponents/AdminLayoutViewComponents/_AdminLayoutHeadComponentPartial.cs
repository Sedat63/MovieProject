using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
