using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Currencies;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Infrastructure.QueryObjects.SystemConfigurations.CurrencyQuery;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Currencies
{
    public class CurrencyQueryRepository : QueryRepositoryBase<Currency>, ICurrencyQueryRepository
    {
        public CurrencyQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<Currency?> GetById(long id)
        {
            return await _context.Set<Currency>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Currency?> GetByCode(string code)
        {
            return await _context.Set<Currency>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CurrencyDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CurrencyQueryRepository = new CurrencyQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CurrencyQueryRepository.Query(sqlQueryOptions);
        }






    }
}
