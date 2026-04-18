using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands;

namespace MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public int MovieId { get; set; }
        public RemoveMovieCommand(int movieId)
        {
            MovieId = movieId;
        }
    }
}

