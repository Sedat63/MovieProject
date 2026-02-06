using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handler(RemoveCategoryCommand removeCategoryCommand)
        {
            var value = await _context.Categories.FindAsync(removeCategoryCommand.CategoryId);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
