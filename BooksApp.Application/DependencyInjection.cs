using BooksApp.Application.Mappings;
using BooksApp.Application.Services;
using BooksApp.Application.ServicesInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApp.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);

            services.ServicesInit();
        }

        private static void ServicesInit(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPublishingHouseService, PublishingHouseService>();
        }
    }
}
