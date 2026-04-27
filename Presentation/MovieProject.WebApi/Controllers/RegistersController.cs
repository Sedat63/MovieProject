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

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateUserRegisterBulk(List<CreateUserRegisterCommand> commands)
        {
            foreach (var command in commands)
            {
                await _createUserRegisterCommandHandler.Handle(command);
            }
            return Ok($"{commands.Count} Kullanıcı Başarıyla Eklendi");
        }
    }
}
