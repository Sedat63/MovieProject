using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MovieProject.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieProject.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagQuery:IRequest<List<GetTagQueryResult>>
    {
    }
}
