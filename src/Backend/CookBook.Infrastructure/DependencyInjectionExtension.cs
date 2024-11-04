using CookBook.Domain.Repositories;
using CookBook.Domain.Repositories.User;
using CookBook.Domain.Security.Criptography;
using CookBook.Domain.Security.Tokens;
using CookBook.Domain.Services.LoggedUser;
using CookBook.Infrastructure.DataAccess;
using CookBook.Infrastructure.DataAccess.Repositories;
using CookBook.Infrastructure.Extensions;
using CookBook.Infrastructure.Security.Criptography;
using CookBook.Infrastructure.Security.Tokens.Access.Generator;
using CookBook.Infrastructure.Security.Tokens.Access.Validator;
using CookBook.Infrastructure.Services.LoggedUser;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CookBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            AddPasswordEncrypter(service, configuration);
            AddRepositories(service, configuration);
            AddTokens(service, configuration);
            AddLoggedUser(service);

            if (configuration.IsUnitTestEnviroment())
                return;

            AddDbContext(service, configuration);
            AddFluentMigrator_MySql(service, configuration);
        }

        private static void AddDbContext(IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();
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
            service.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
        }

        private static void AddFluentMigrator_MySql(IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            service.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddMySql5()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("CookBook.Infrastructure")).For.All();
            });
        }

        private static void AddTokens(IServiceCollection service, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationTimeMinutes");
            var signinKey = configuration.GetValue<string>("Settings:Jwt:SigninKey");

            service.AddScoped<IAccessTokenGenerator>(option => new JwtTokenGenerator(expirationTimeMinutes, signinKey!));
            service.AddScoped<IAccessTokenValidator>(option => new JwtTokenValidator(signinKey!));
        }

        private static void AddLoggedUser(IServiceCollection service) => service.AddScoped<ILoggedUser, LoggedUser>();

        private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetValue<string>("Settings:Password:AddionalKey");

            services.AddScoped<IPasswordEncrypter>(option => new Sha512Encrypter(additionalKey!));
        }
    }
}
