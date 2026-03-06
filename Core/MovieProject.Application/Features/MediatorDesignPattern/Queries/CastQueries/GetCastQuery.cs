using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MovieProject.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieProject.Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    public class GetCastQuery : IRequest<List<GetCastQueryResult>>
    {
    }
}
