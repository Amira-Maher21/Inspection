using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Query.SharedRepository;
using Inspection.Application.Managers;
using Inspection.Infrastructure.Repositories.Query.SharedRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Inspection.Application.Extensions
{
    public static class AccountsApplicationExtensions
    {
        public static IServiceCollection AddAccountsApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountsServicesManger, AccountsServicesManger>();
            services.AddAutoMapper(typeof(AccountsApplicationAssemblyReference).Assembly);
           // services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //services.AddScoped(typeof(IGenericLookupRepository<,>), typeof(GenericLookupRepository<,>));


            return services;
        }
    }
}
