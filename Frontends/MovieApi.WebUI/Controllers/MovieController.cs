using System.Net;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public MovieController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "AnaSayfa";
            ViewBag.v3 = "Tüm Filmler";


            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Movies");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(values); 
            }

            return View();




            //        try
            //        {
            //            var responseMessage = await client.GetAsync("https://localhost:7221/api/Movies");


            //            if (responseMessage.IsSuccessStatusCode)
            //            {
            //                var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
            //                return View(values ?? new List<ResultMovieDto>()); // Null gelirse boş liste
            //            }
            //            else
            //            {
            //                // API hata kodu döndürdüyse (404, 500 vb.)
            //                Console.WriteLine($"API Hatası: {responseMessage.StatusCode}");
            //                return View(new List<ResultMovieDto>()); // Boş liste gönder
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            // Bağlantı hatası, timeout vb.
            //            Console.WriteLine($"Hata: {ex.Message}");
            //            return View(new List<ResultMovieDto>()); //Boş liste gönder
            //        }
        }
    }
}
