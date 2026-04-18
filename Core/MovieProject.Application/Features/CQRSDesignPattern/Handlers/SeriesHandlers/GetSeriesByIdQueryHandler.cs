using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieProject.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using MovieProject.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetSeriesByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetSeriesByIdQueryResult>Handle(GetSeriesByIdQuery getSeriesByIdQuery)
        {
            var value = await _context.Serieses.FindAsync(getSeriesByIdQuery.SeriesId);

            return new GetSeriesByIdQueryResult
            {
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Rating = value.Rating,
                Status = value.Status,
                Title = value.Title,
                AverageEpisodeDuration = value.AverageEpisodeDuration,
                CategoryId = value.CategoryId,
                EpisodeCount = value.EpisodeCount,
                FirstAirDate = value.FirstAirDate,
                SeasonCount = value.SeasonCount,
                SeriesId = value.SeriesId,
            };
        }
    }
}
