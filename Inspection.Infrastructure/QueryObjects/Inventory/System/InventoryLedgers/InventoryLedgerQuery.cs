using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.System.InventoryLedgers
{

    public class InventoryLedgerQuery : QueryObjectBase<InventoryLedgerReturnSearchDto>
    {
        public InventoryLedgerQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.InventoryLedger";

                var selectFields = new[]
                {
                    "Id",
                    "CompanyId",
                    "Tenant_ID",
                    "BranchId",
                    "WarehouseId",
                    "WarehouseLocationId",
                    "ItemId",
                    "CurrencyId",
                    "UnitOfMeasureId",
                    "TransactionDate",
                    "PostingDate",
                    "QuantityIn",
                    "QuantityOut",
                    "BalanceAfter",
                    "UnitCost",
                    "TransactionType",
                    "SourceType",
                    "ReferenceDocumentId",
                    "CostingMethod",
                    "Description",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id"
                );
                var warehouseJoin = new JoinTable(
                    "Inventory.Warehouse",
                    "Code WarehouseCode, Name WarehouseName",
                    "WarehouseId Id"
                );
                var locationJoin = new JoinTable(
                    "Inventory.WarehouseLocation",
                    "Code LocationCode, Name LocationName",
                    "WarehouseLocationId Id"
                );
                var itemJoin = new JoinTable(
                    "Inventory.Item",
                    "Code ItemCode, Name ItemName",
                    "ItemId Id"
                );
                var uomJoin = new JoinTable(
                    "Inventory.UnitOfMeasure",
                    "Code UoMCode, Name UoMName",
                    "UnitOfMeasureId Id"
                );
                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        branchJoin,
                        warehouseJoin,
                        locationJoin,
                        itemJoin,
                        uomJoin,
                        currencyJoin,
                    },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<InventoryLedgerReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}