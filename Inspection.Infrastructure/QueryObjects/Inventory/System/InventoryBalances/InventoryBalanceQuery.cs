using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.System.InventoryBalances
{
    public class InventoryBalanceQuery : QueryObjectBase<InventoryBalanceReturnSearchDto>
    {
        public InventoryBalanceQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.InventoryBalance";

                var selectFields = new[]
                {
            "Id",
            "ItemId",
            "WarehouseId",
            "BaseUoMId",
            "Quantity",
            "ReservedQuantity",
            "AvailableQuantity",
            "AverageCost",
            "WarehouseLocationId",
            "CompanyId",
            "Tenant_ID",
            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                // Joins
                var itemJoin = new JoinTable("Inventory.Item", "Code ItemCode, Name ItemName", "ItemId Id");
                var warehouseJoin = new JoinTable("Inventory.Warehouse", "Code WarehouseCode, Name WarehouseName", "WarehouseId Id");
                var uomJoin = new JoinTable("Inventory.UnitOfMeasure", "Code UoMCode, Name UoMName", "BaseUoMId Id");
                var locationJoin = new JoinTable("Inventory.WarehouseLocation", "Code LocationCode, Name LocationName", "WarehouseLocationId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { itemJoin, warehouseJoin, uomJoin, locationJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<InventoryBalanceReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}