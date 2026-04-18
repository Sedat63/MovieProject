using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Dto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;

namespace MovieProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public AdminMovieController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> MovieList()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Movies");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateAdminMovieDto createAdminMovieDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAdminMovieDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Movies", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }

            return View();
        }
    }
}

/*
 
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AdminCreateCategoryDto adminCreateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminCreateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7221/api/Categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            return View();
        }
 
 */