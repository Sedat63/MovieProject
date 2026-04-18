using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieProject.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;

namespace MovieProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;

        public SeriesesController(GetSeriesQueryHandler getSeriesQueryHandler, GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler)
        {
            _getSeriesQueryHandler = getSeriesQueryHandler;
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var result = await _getSeriesQueryHandler.Handle();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand createSeriesCommand)
        {
            await _createSeriesCommandHandler.Handle(createSeriesCommand);
            return Ok("Dizi Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id));
            return Ok("Dizi Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand updateSeriesCommand)
        {
            await _updateSeriesCommandHandler.Handle(updateSeriesCommand);
            return Ok("Dizi Güncelleme İşlemi Başarılı");
        }


        [HttpGet("GetSeriesById")]
        public async Task<IActionResult> GeteriesById(int id)
        {
            var value= await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id));
            return Ok(value);
        }
     
    }
}
