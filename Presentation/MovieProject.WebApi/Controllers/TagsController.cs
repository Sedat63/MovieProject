using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieProject.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieProject.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _mediator.Send(new GetTagQuery());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand createTagCommand)
        {
            await _mediator.Send(createTagCommand);
            return Ok(("Ekleme İşlemi Başarılı"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand updateTagCommand)
        {
            await _mediator.Send(updateTagCommand);
            return Ok(("Güncelleme İşlemi Başarılı"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok();
        }
    }
}
