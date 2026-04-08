using Microsoft.AspNetCore.Identity;
using MovieProject.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieProject.Persistance.Context;
using MovieProject.Persistance.Identity;

namespace MovieProject.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _movieContext;
        private readonly UserManager<AppUser> _userManager;
       
        public CreateUserRegisterCommandHandler(MovieContext movieContext, UserManager<AppUser> userManager)
        {
            _movieContext = movieContext;
            _userManager = userManager;
        }

        public async Task Handle(CreateUserRegisterCommand createUserRegisterCommand)
        {
            var user = new AppUser()
            {
                Name = createUserRegisterCommand.Name,
                surname = createUserRegisterCommand.Surname,
                Email = createUserRegisterCommand.Email,
                UserName = createUserRegisterCommand.Username
            };

            await _userManager.CreateAsync(user, createUserRegisterCommand.Password);
        }
    }
}
