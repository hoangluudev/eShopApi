using FluentValidation;
using System.Reflection;

namespace eShopApi.Configurations
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(FluentValidationConfig).Assembly);
            return services;
        }
    }
}