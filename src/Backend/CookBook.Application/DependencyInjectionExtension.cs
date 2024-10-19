using CookBook.Application.Services.AutoMapper;
using CookBook.Application.Services.Cryptography;
using CookBook.Application.UseCases.User.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
            AddPasswordEncrypter(service, configuration);
            AddAutoMapper(service);
            AddUseCase(service);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(options => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetValue<string>("Settings:Password:AddionalKey");

            services.AddScoped(option => new PasswordEncryter(additionalKey!));
        }
    }
}
