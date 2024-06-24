using BooksApp.Domain;
using BooksApp.Domain.RepositoryInterfaces;
using BooksApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                                     npgsqlOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly("BooksApp.Infrastructure");
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                                     });
            });

            services.RepositoriesInit();
        }

        private static void RepositoriesInit(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPublishingHouseRepository, PublishingHouseRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
