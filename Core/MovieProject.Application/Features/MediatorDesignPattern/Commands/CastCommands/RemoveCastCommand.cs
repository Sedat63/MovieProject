using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MovieProject.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand:IRequest
    {
        public int CastId { get; set; }

        public RemoveCastCommand(int castId)
        {
            CastId = castId;
        }

        
    }
}
