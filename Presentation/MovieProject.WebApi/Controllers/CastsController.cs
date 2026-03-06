using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieProject.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList() 
        {
            var value = await _mediator.Send(new GetCastQuery());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand createCastCommand)
        {
            await _mediator.Send(createCastCommand);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand updateCastCommand)
        {
            await _mediator.Send(updateCastCommand);
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id) 
        { 
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetCastById")]
        public async Task<IActionResult> GetCastById(int id) 
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok();
        }       
    }
}
