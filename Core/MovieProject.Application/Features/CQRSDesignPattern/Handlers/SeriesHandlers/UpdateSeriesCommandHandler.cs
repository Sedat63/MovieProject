using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieProject.Domain.Entities;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class UpdateSeriesCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSeriesCommand updateSeriesCommand)
        {
            var value = await _context.Serieses.FindAsync(updateSeriesCommand.SeriesId);
            value.CoverImageUrl = updateSeriesCommand.CoverImageUrl;
            value.CreatedYear = updateSeriesCommand.CreatedYear;
            value.Description = updateSeriesCommand.Description;
            value.Rating = updateSeriesCommand.Rating;
            value.Status = updateSeriesCommand.Status;
            value.Title = updateSeriesCommand.Title;
            value.AverageEpisodeDuration = updateSeriesCommand.AverageEpisodeDuration;
            value.CategoryId = updateSeriesCommand.CategoryId;
            value.EpisodeCount = updateSeriesCommand.EpisodeCount;
            value.FirstAirDate = updateSeriesCommand.FirstAirDate;
            value.SeasonCount = updateSeriesCommand.SeasonCount;
            await _context.SaveChangesAsync();
        }
    }
}
