using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public int MovieId { get; set; }
    }
}
