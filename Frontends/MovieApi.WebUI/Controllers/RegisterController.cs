using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Dto.Dtos.UserRegisterDtos;
using Newtonsoft.Json;

namespace MovieProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserRegisterDto createUserRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserRegisterDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7221/api/Registers", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Login");
            }

            ViewBag.error = "Kayıt Başarısız Oldu Tekrar Deneyin";
            return View();
        }
    }
}
