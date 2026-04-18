using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieProject.Domain.Entities;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {
        private readonly MovieContext _context;

        public CreateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSeriesCommand createSeriesCommand)
        {
            _context.Serieses.Add(new Series
            {
                CoverImageUrl = createSeriesCommand.CoverImageUrl,
                CreatedYear = createSeriesCommand.CreatedYear,
                Description = createSeriesCommand.Description,
                Rating = createSeriesCommand.Rating,
                Status = createSeriesCommand.Status,
                Title = createSeriesCommand.Title,
                AverageEpisodeDuration = createSeriesCommand.AverageEpisodeDuration,
                CategoryId = createSeriesCommand.CategoryId,
                EpisodeCount = createSeriesCommand.EpisodeCount,
                FirstAirDate = createSeriesCommand.FirstAirDate,
                SeasonCount = createSeriesCommand.SeasonCount,
            });
            await _context.SaveChangesAsync();
        }
    }
}
