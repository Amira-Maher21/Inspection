using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Infrastructure.DataContext;
using Inspection.Infrastructure.Managers;
using Inspection.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NDS.Shared.Infrastructure.Extensions;

namespace Inspection.Infrastructure.Extensions
{
    public static class AccountsInfrastructureExtensions
    {
        public static IServiceCollection AddAccountsRepositoryManagers(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            services.AddSharedInfrastructure();
            services.AddDbContext<DbInspectionContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("Inspection"));
            });
            services.AddScoped<IAccountsQueriesManager, AccountQueriesManager>();
            services.AddScoped<IAccountUnitOfWork, AccountUoW>();


            return services;
        }
    }
}
