using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetAccountingEvents
{
    public class AssetAccountingEventQuery : QueryObjectBase<AssetAccountingEvent>
    {
        public AssetAccountingEventQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetAccountingEvent>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetAccountingEvent";
                string fields = "[Id],[Code],[Name], [AssetEventType],[SourceModule],[Tenant_ID],[IsReversible],[Disabeld]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<AssetAccountingEvent>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<AssetAccountingEvent>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<AssetAccountingEvent>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetAccountingEvent>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<AssetAccountingEvent>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<AssetAccountingEvent>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

