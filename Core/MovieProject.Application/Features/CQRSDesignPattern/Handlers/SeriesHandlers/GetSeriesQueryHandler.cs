using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieProject.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesQueryHandler
    {
        private readonly MovieContext _context;

        public GetSeriesQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetSeriesQueryResult>> Handle()
        {
            var values = await _context.Serieses.ToListAsync();
            return values.Select(s => new GetSeriesQueryResult
            {
                CoverImageUrl = s.CoverImageUrl,
                CreatedYear = s.CreatedYear,
                Description = s.Description,
                Rating = s.Rating,
                Status = s.Status,
                Title = s.Title,
                AverageEpisodeDuration = s.AverageEpisodeDuration,
                CategoryId = s.CategoryId,
                EpisodeCount = s.EpisodeCount,
                FirstAirDate = s.FirstAirDate,
                SeasonCount = s.SeasonCount,
            }).ToList();
        }
    }
}
