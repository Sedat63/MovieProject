using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieProject.Domain.Entities;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handler(CreateMovieCommand createMovieCommand)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = createMovieCommand.CoverImageUrl,
                CreatedYear = createMovieCommand.CreatedYear,
                Description = createMovieCommand.Description,
                Duration = createMovieCommand.Duration,
                Rating = createMovieCommand.Rating,
                ReleaseDate = createMovieCommand.ReleaseDate,
                Status = createMovieCommand.Status,
                Title = createMovieCommand.Title,
            });

            await _context.SaveChangesAsync();
        }
    }
}
