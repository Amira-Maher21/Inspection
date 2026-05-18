using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.System.InventoryCostLayers
{
    internal class InventoryCostLayerQuery : QueryObjectBase<InventoryCostLayerReturnSearchDto>
    {
        public InventoryCostLayerQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.InventoryCostLayer";

                var selectFields = new[]
                {
            "Id",
            "ItemId",
            "WarehouseId",
            "QuantityIn",
            "QuantityOut",
            "RemainingQty",
            "UnitCost",
            "SourceTransactionId",
            "TransactionDate",
            "CompanyId",
            "Tenant_ID",
            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                var itemJoin = new JoinTable("Inventory.Item", "Code ItemCode, Name ItemName", "ItemId Id");
                var warehouseJoin = new JoinTable("Inventory.Warehouse", "Code WarehouseCode, Name WarehouseName", "WarehouseId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { itemJoin, warehouseJoin },
                    queryOptions
                );

                // تنفيذ الاستعلام باستخدام Dapper
                var queryResult = await _dapper.QueryList<InventoryCostLayerReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}