using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MovieProject.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class CreateTagCommand:IRequest
    {       
        public string Title { get; set; }
    }
}
