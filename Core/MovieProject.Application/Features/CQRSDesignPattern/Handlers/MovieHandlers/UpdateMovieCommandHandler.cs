using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handler(UpdateMovieCommand updateMovieCommand)
        {
            var value = await _context.Movies.FindAsync(updateMovieCommand.MovieId);
            value.Rating = updateMovieCommand.Rating;
            value.Status = updateMovieCommand.Status;
            value.Duration = updateMovieCommand.Duration;
            value.CreatedYear = updateMovieCommand.CreatedYear;
            value.CoverImageUrl = updateMovieCommand.CoverImageUrl;
            value.Description = updateMovieCommand.Description;
            value.ReleaseDate = updateMovieCommand.ReleaseDate;
            value.Title = updateMovieCommand.Title;
            await _context.SaveChangesAsync();
        }
    }
}
