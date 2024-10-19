using CookBook.Domain.Entities;
using CookBook.Domain.Repositories;
using CookBook.Domain.Repositories.User;
using CookBook.Infrastructure.DataAccess;
using CookBook.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            AddDbContext(service, configuration);
            AddRepositories(service, configuration);
        }

        private static void AddDbContext(IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionMySql");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

            service.AddDbContext<CookBookDbContext>(DbContextOptions =>
            {
                DbContextOptions.UseMySql(connectionString, serverVersion);
            });
        }
        
        private static void AddRepositories(IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            service.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
