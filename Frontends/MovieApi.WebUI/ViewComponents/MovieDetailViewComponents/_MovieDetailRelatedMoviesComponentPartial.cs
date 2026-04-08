using Microsoft.AspNetCore.Mvc;

namespace MovieProject.WebUI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRelatedMoviesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
