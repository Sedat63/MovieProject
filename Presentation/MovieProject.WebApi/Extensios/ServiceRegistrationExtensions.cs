using MovieProject.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieProject.WebApi.Extensios
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            //Category
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();

            //Movie
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();

            //Series
            services.AddScoped<GetSeriesQueryHandler>();
            services.AddScoped<GetSeriesByIdQueryHandler>();
            services.AddScoped<CreateSeriesCommandHandler>();
            services.AddScoped<RemoveSeriesCommandHandler>();
            services.AddScoped<UpdateSeriesCommandHandler>();

            //user
            services.AddScoped<CreateUserRegisterCommandHandler>();

            return services;
        }
    }
}
