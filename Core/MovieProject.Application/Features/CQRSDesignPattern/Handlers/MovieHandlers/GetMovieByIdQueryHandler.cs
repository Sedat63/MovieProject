using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieProject.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery getMovieByIdQuery)
        {
            var value = await _context.Movies.FindAsync(getMovieByIdQuery.MovieId);
            return new GetMovieByIdQueryResult
            {
                CreatedYear = value.CreatedYear,
                MovieId = value.MovieId,
                CoverImageUrl = value.CoverImageUrl,
                Description = value.Description,
                Duration = value.Duration,
                Rating = value.Rating,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status,
                Title = value.Title,
            };
        }
    }
}
