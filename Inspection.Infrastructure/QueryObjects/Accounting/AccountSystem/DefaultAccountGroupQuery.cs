using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSystem
{
    public class DefaultAccountGroupQuery : QueryObjectBase<DefaultAccountGroup>
    {
        public DefaultAccountGroupQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DefaultAccountGroup>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.DefaultAccountGroup";
                string fields = "[Id],[GroupCode],[GroupName], [EntityType],[Tenant_ID]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<DefaultAccountGroup>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DefaultAccountGroup>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DefaultAccountGroup>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DefaultAccountGroup>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<DefaultAccountGroup>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<DefaultAccountGroup>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
