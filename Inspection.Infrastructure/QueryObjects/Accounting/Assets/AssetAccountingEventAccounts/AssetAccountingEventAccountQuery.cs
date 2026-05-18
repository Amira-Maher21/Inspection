using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetAccountingEventAccounts
{
    public class AssetAccountingEventAccountQuery : QueryObjectBase<AssetAccountingEventAccount>
    {
        public AssetAccountingEventAccountQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetAccountingEventAccount>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetAccountingEventAccount";
                string fields = "[Id],[AssetAccountingEventId],[DebitAccountRole], [CreditAccountRole],[AmountSource],[Disabled],[Tenant_ID]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<AssetAccountingEventAccount>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<AssetAccountingEventAccount>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<AssetAccountingEventAccount>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetAccountingEventAccount>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<AssetAccountingEventAccount>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<AssetAccountingEventAccount>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

