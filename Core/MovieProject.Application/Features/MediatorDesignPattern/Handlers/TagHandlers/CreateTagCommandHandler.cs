using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MovieProject.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieProject.Domain.Entities;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly MovieContext _context;

        public CreateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await _context.Tags.AddAsync(new Tag
            {
                Title = request.Title,
            });
            await _context.SaveChangesAsync();
        }
    }
}
