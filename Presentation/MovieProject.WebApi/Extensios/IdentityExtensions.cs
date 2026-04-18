using Microsoft.AspNetCore.Identity;
using MovieProject.Persistance.Context;
using MovieProject.Persistance.Identity;

namespace MovieProject.WebApi.Extensios
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>();
            return services;
        }
    }
}
