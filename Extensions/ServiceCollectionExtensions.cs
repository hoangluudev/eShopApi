

using System.Reflection;
using eShopApi.Repositories.Implementations;
using eShopApi.Repositories.Interfaces;
using eShopApi.Services.Implementations;
using eShopApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace eShopApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPasswordHasher<Models.Entities.User>, PasswordHasher<Models.Entities.User>>();

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}