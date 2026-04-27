using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieWithCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieWithCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
        {
            var values = await _context.Movies.Include(c=>c.Category).ToListAsync();
            return values.Select(m => new GetMovieWithCategoryQueryResult
            {
                MovieId = m.MovieId,
                CoverImageUrl = m.CoverImageUrl,
                CreatedYear = m.CreatedYear,
                Description = m.Description,
                Duration = m.Duration,
                Rating = m.Rating,
                ReleaseDate = m.ReleaseDate,
                Status = m.Status,
                Title = m.Title,
                CategoryId = m.CategoryId,
                CategoryName=m.Category.CategoryName,
            }).ToList();
        }
    }
}
