using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(RemoveMovieCommand removeMovieCommand)
        {
            var value = await _context.Movies.FindAsync(removeMovieCommand.MovieId);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
