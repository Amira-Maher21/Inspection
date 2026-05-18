using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SalesManagment.SalesReturns
{
    public class SalesReturnQuery : QueryObjectBase<SalesReturnReturnSearchDto>
    {
        public SalesReturnQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Sales.SalesReturn";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "ReturnNumber",
                    "ReturnDate",

                    "SalesInvoiceId",
                    "CustomerId",

                    "ChartOfAccountId",
                    "WarehouseId",
                    "CurrencyId",
                    "FiscalYearId",

                    "Description",
                    "ReturnReason",

                    "NetAmount",
                    "TaxAmount",
                    "TotalAmount",

                    "Posting",
                    "ApprovalStatus",

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

                var customerJoin = new JoinTable(
                    "Accounting.Customer",
                    "Code CustomerCode, Name CustomerName",
                    "CustomerId Id"
                );
                var FiscalYearJoin = new JoinTable(
                    "Accounting.FiscalYear",
                    "Code FiscalYearCode ",
                    "FiscalYearId Id"
                );

                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id"
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

                var ChartOfAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode ChartOfAccounCode, AccountName ChartOfAccounName",
                    "ChartOfAccountId Id"
                );

                var salesInvoiceJoin = new JoinTable(
                    "Accounting.SalesInvoice",
                    "InvoiceNo SalesInvoiceCode",
                    "SalesInvoiceId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        customerJoin,
                        branchJoin,
                        currencyJoin,
                        warehouseJoin,
                        ChartOfAccountJoin,
                        FiscalYearJoin,
                        salesInvoiceJoin
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<SalesReturnReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>.Fail(result.Errors);

                var data = result.Result?.ToList() ?? new List<SalesReturnReturnSearchDto>();

                return ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}