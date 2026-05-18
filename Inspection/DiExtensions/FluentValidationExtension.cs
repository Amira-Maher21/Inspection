using FluentValidation;
using Inspection.API.Controllers;

namespace Inspection.API.Main.DiExtensions
{
    internal static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidationExtensions(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AccountsApiControllersAssemblyReference>();

            return services;
        }
    }
}

