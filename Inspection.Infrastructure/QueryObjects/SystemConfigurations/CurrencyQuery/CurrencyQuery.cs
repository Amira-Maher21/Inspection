using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SystemConfigurations.CurrencyQuery
{
    internal class CurrencyQuery : QueryObjectBase<CurrencyDto>
    {
        public CurrencyQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CurrencyDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Sec.Currency";
                string fields = "[Id], [Name],[Code], [Tenant_ID], [Sub_Currency],[CurrencySymbol],[Disabled]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<CurrencyDto>(query.QueryString!, query.Parameters!.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CurrencyDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<CurrencyDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CurrencyDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CurrencyDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CurrencyDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}