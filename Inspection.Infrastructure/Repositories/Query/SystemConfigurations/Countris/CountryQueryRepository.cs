using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Countries;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using Inspection.Infrastructure.QueryObjects.SystemConfigurations.CountryQuerys;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Countris
{
    public class CountryQueryRepository : QueryRepositoryBase<Country>, ICountriesQueryRepository
    {
        public CountryQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Country?> GetByCode(string code)
        {
            return await _context.Set<Country>()
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();
        }


        public async Task<Country?> GetById(long id)
        {
            return await _context.Set<Country>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _context.Set<Country>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<CountryDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var countryQuery = new CountryQuery(
                _queryBuilder,
                _dapper,
                _tenantResolver,
                _exceptionManager
            );

            return await countryQuery.Query(sqlQueryOptions);
        }








    }
}
