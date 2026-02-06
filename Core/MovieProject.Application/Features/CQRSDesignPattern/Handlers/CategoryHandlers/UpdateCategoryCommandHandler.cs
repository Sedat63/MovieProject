using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handler(UpdateCategoryCommand updateCategoryCommand)
        {
            var value = await _context.Categories.FindAsync(updateCategoryCommand.CategoryId);
            value.CategoryId = updateCategoryCommand.CategoryId;
            await _context.SaveChangesAsync();
        }
    }
}
