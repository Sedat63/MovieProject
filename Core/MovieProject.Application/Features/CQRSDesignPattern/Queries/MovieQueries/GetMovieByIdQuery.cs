using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Features.CQRSDesignPattern.Queries.MovieQueries
{
    public class GetMovieByIdQuery
    {
        public int MovieId { get; set; }
    }
}
