using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Sizs
{
    internal class SizeQuery : QueryObjectBase<SizeDto>
    {
        public SizeQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SizeDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inventory.Size";
                string fields = "[Id], [Name],[Code], [Tenant_ID], [Description]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<SizeDto>(query.QueryString!, query.Parameters!.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<SizeDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<SizeDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SizeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SizeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<SizeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
