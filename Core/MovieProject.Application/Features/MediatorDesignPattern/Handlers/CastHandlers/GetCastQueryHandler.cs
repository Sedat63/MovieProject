using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieProject.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
           var values = await _context.Casts.ToListAsync();
            return values.Select(c => new GetCastQueryResult
            {
                CastId = c.CastId,
                Biography = c.Biography,
                ImageUrl = c.ImageUrl,
                Name = c.Name,
                Overview = c.Overview,
                surname = c.surname,
                Title = c.Title,
            }).ToList();
        }
    }
}

//Listeleme ve id'ye göre getirme işlemlerinde request yaptığımız yer ve sonucu da getirmemiz gerekir
//CastCommandHandler class'ında request yaptığımız kısım GetCastQuery, sonucunu aldığımız kısım, GetCastQueryResult liste olduğu için de List kullanılır.
/*
 AsNoTracking üzerinde sadece read işlemi yapılacak işlemlerde kullandığımız bir ef core fonksiyonudur.Normalde ef core entity üzerinde tracking başlatır ve yapılan değişikleri takip ederek savechanges ile veritabanına yansıtır.Ama read işleminde savechanges gerek olmadığı ve entity üzerinde bir güncelleme yapmadığımız için performans artışı için AsNoTracking kullanırız.


 */