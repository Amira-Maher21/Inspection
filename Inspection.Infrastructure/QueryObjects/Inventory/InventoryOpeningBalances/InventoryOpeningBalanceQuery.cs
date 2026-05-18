using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventoryOpeningBalances
{

    public class InventoryOpeningBalanceQuery : QueryObjectBase<InventoryOpeningBalanceReturnSearchDto>
    {
        public InventoryOpeningBalanceQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }



        public override async Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.InventoryOpeningBalance";

                var selectFields = new[]
                {
            "Id",
            "Tenant_ID",
            "CompanyId",
            "WarehouseId",
            "FiscalYearId",
            "BranchId",
            "CurrencyId",
            "Posting",
            "TotalValue",
            "YearEndCarryForward",
            "Description",
            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                var fiscalYearJoin = new JoinTable
                            ("Accounting.FiscalYear",
                            "Code FiscalYearCode",
                            "FiscalYearId Id");

                var branchJoin = new JoinTable
                    ("Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id");

                var warehouseJoin = new JoinTable
                    ("Inventory.Warehouse",
                    "Code WarehouseCode, Name WarehouseName",
                    "WarehouseId Id");

                var currencyJoin = new JoinTable
                    ("Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id");


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { fiscalYearJoin, branchJoin, warehouseJoin, currencyJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<InventoryOpeningBalanceReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}