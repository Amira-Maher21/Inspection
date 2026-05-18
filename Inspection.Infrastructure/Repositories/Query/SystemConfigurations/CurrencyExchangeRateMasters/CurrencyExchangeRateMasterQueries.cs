using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using Inspection.Infrastructure.QueryObjects.SystemConfigurations.CurrencyExchangeRateQueryMasters;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SystemConfigurations.CurrencyExchangeRateMasters
{



    public class CurrencyExchangeRateMasterQueries : QueryRepositoryBase<CurrencyExchangRate>, ICurrencyExchangeRateQueryRepository
    {

        public CurrencyExchangeRateMasterQueries(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }


        public async Task<CurrencyExchangRate?> GetById(long id)
        {
            return await _dbSet
                .Include(x => x.Details)
                .Include(x => x.Currency)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var CurrencyExchangeRateQueryMaster = new CurrencyExchangeRateQueryMaster(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await CurrencyExchangeRateQueryMaster.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



    }
}
