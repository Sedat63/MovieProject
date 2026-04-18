using MovieProject.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

namespace MovieProject.WebApi.Extensios
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        {
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
            return services;
        }
    }
}
