using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Dto.Dtos.AdminDtos.AdminSeriesDtos;
using Newtonsoft.Json;

namespace MovieProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSeriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public AdminSeriesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> SeriesList()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Serieses");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultSeriesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSeries()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateAdminSeriesDto createAdminSeriesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAdminSeriesDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Serieses", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }

            return View();
        }
    }
}
