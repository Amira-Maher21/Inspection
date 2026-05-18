using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.UnitOfMeasure
{
    public class UnitOfMeasureQuery : QueryObjectBase<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>
    {
        public UnitOfMeasureQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.UnitOfMeasure";
                string fields = "[Id],[Code],[Tenant_ID], [Name],[Description],[IsBaseUnit]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

