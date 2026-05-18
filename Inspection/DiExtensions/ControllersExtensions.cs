using Inspection.API.Controllers;

namespace Inspection.API.Main.DiExtensions
{
    public static class ControllersExtensions
    {
        public static IMvcBuilder AddControllersExtensions(this IServiceCollection services)
        {
            return services
                  .AddControllers()
                  .AddApplicationPart(typeof(AccountsApiControllersAssemblyReference).Assembly);
        }
    }
}
