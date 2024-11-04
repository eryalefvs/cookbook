using CookBook.Application.Services.AutoMapper;
using CookBook.Application.UseCases.Login.DoLogin;
using CookBook.Application.UseCases.Profile;
using CookBook.Application.UseCases.User.ChangePassword;
using CookBook.Application.UseCases.User.Register;
using CookBook.Application.UseCases.User.Update;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
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
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        }
    }
}
