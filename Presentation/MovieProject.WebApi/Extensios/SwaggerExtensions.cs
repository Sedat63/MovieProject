using Microsoft.OpenApi.Models;

namespace MovieProject.WebApi.Extensios
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
           services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movia", Version = "v1" });
            });

            return services;
        }
    }
}
