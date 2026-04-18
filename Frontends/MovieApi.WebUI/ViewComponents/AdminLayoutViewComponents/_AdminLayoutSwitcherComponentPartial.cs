using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSwitcherComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
