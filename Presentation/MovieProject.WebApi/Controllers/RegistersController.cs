using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _createUserRegisterCommandHandler;

        public RegistersController(CreateUserRegisterCommandHandler createUserRegisterCommandHandler)
        {
            _createUserRegisterCommandHandler = createUserRegisterCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRegister(CreateUserRegisterCommand createUserRegisterCommand)
        {
            await _createUserRegisterCommandHandler.Handle(createUserRegisterCommand);
            return Ok("Kullanıcı Başarıyla Eklendi");
        }
    }
}
