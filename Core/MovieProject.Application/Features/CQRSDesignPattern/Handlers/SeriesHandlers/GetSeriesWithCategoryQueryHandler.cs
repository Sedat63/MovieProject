using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesWithCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetSeriesWithCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetSeriesWithCategoryQueryResult>> Handle()
        {
            var values = await _context.Serieses.Include(s => s.Category).ToListAsync();
            return values.Select(s => new GetSeriesWithCategoryQueryResult
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
                SeriesId = s.SeriesId,
                CategoryName = s.Category.CategoryName,
            }).ToList();
        }
    }
}
