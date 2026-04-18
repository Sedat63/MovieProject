using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class RemoveSeriesCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSeriesCommand removeSeriesCommand)
        {
            var value = await _context.Serieses.FindAsync(removeSeriesCommand.SeriesId);
            _context.Serieses.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
