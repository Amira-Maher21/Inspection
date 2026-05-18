using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Infrastructure.QueryObjects.SystemConfigurations.CityQueries;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Cities
{
    public class CityQueryRepository : QueryRepositoryBase<City>, ICityQueryRepository
    {
        public CityQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<City?> GetById(long id)
        {
            return await _context.Set<City>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<City?> GetByCode(string code)
        {
            return await _context.Set<City>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CityQueryRepository = new CityQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CityQueryRepository.Query(sqlQueryOptions);
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _context.Set<City>().AnyAsync(c => c.Id == id);
        }

    }
}