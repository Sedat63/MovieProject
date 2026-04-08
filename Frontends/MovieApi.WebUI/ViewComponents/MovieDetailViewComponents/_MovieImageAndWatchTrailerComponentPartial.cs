using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieImageAndWatchTrailerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
