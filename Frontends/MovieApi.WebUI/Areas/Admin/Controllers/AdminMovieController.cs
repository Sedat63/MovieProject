using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieProject.Dto.Dtos.AdminCategoryDtos;
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

            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Movies/GetMovieWithCategory");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMovie()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<AdminResultCategoryDto>>(jsonData);
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            }

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

