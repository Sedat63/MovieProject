using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MovieProject.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class CreateCastCommand:IRequest
    {       
        public string Title { get; set; }
        public string Name { get; set; }
        public string surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }

    }
}
