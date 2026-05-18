using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AR.PurchaseReturns
{
    public class PurchaseReturnQuery : QueryObjectBase<PurchaseReturnReturnSearchDto>
    {
        public PurchaseReturnQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.PurchaseReturn";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "ReturnNumber",
                    "ReturnDate",

                    "FiscalYearId",
                    "PurchaseInvoiceId",
                    "SupplierId",
                    "ChartOfAccountId",

                    "WarehouseId",
                    "CurrencyId",

                    "Posting",
                    "ApprovalStatus",

                    "NetAmount",
                    "TaxAmount",
                    "TotalAmount",

                    "Description",
                    "ReturnReason",
                    "NetAmount",
                    "TaxAmount",
                    "TotalAmount",
                    "AdditionalDiscountType",
                    "AdditionalDiscountValue",
                    "AdditionalDiscountAmount",
                    "TotalDiscount",

                     "SeriesId",
                    "RunningNumber",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // ================== JOINS ==================

                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id"
                );
                var FiscalYearJoin = new JoinTable(
                    "Accounting.FiscalYear",
                    "Code FiscalYearCode",
                    "FiscalYearId Id"
                );

                var PurchaseInvoiceJoin = new JoinTable(
                    "Accounting.PurchaseInvoice",
                    "InvoiceNo PurchaseInvoiceCode",
                    "PurchaseInvoiceId Id"
                );
                var SupplierJoin = new JoinTable(
                    "Accounting.Supplier",
                    "Code SupplierCode,Name SupplierName",
                    "SupplierId Id"
                );
                var ChartOfAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode ChartOfAccountCode,AccountName ChartOfAccountName",
                    "ChartOfAccountId Id"
                );

                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id"
                );

                var warehouseJoin = new JoinTable(
                    "Inventory.Warehouse",
                    "Code WarehouseCode, Name WarehouseName",
                    "WarehouseId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        SupplierJoin,
                        FiscalYearJoin,
                        PurchaseInvoiceJoin,
                         branchJoin,
                        ChartOfAccountJoin,
                        currencyJoin,
                        warehouseJoin
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<PurchaseReturnReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>.Fail(result.Errors);

                var data = result.Result?.ToList()
                           ?? new List<PurchaseReturnReturnSearchDto>();

                return ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}