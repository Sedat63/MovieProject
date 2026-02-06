using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieProject.Domain.Entities;
using MovieProject.Persistance.Context;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(CreateCategoryCommand createCategoryCommand)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = createCategoryCommand.CategoryName,
            });

            await _context.SaveChangesAsync();
        }
    }
}
