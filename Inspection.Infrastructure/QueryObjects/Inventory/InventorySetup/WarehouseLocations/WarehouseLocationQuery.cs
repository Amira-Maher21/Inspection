using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationQuery : QueryObjectBase<WarehouseLocationSearchReturnDto>
    {
        public WarehouseLocationQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Query(
     SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.WarehouseLocation";

                var selectFields = new[]
                {
            "Id",
            "Name",
            "Code",
            "Tenant_ID",
            "IsLeaf",
            "WarehouseId",
            "ParentLocationId",
            "LocationType",
            "Capacity",
            "Description"
        };

                var joinTableName = "Inventory.Warehouse";
                var joinSelectFields = "Code WarehouseCode, Name WarehouseName";
                var joinField = "WarehouseId Id";

                var joinTable = new JoinTable(
                    joinTableName,
                    joinSelectFields,
                    joinField
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { joinTable },
                    queryOptions
                );

                var queryResult =
                    await _dapper.QueryList<WarehouseLocationSearchReturnDto>(
                        queryData.QueryString!,
                        queryData.Parameters!.ToDictionary()
                    );

                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
