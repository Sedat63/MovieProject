using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MovieProject.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieProject.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
           var values = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = values.CastId,
                Biography = values.Biography,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                Overview = values.Overview,
                Title = values.Title,
                surname = values.surname
            };
        }
    }
}
