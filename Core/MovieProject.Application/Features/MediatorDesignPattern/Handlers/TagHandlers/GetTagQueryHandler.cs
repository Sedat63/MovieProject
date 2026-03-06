using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieProject.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;

        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.ToListAsync();
            return values.Select(t => new GetTagQueryResult
            {
                TagId = t.TagId,
                Title = t.Title,
            }).ToList();
        }
    }
}
