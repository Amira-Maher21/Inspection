using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceQuery : QueryObjectBase<PurchaseInvoiceReturnSearchDto>
    {
        public PurchaseInvoiceQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.PurchaseInvoice";

                var selectFields = new[]
                 {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "WarehouseId",
                    "InvoiceNo",
                    "InvoiceDate",

                    "SupplierId",
                    "SalesOrderId",

                    "CurrencyId",
                    "PaymentTermId",

                    "SalesPersonId",

                    "Posting",
                    "ApprovalStatus",
                    "Status",

                    "TotalAmount",
                    "TaxAmount",
                    "Notes",

                    "SeriesId",
                    "RunningNumber",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // ================== JOINS ==================

                var supplierJoin = new JoinTable(
                    "Accounting.Supplier",
                    "Code SupplierCode, Name SupplierName",
                    "SupplierId Id"
                );

                var WarehouseJoin = new JoinTable(
                    "Inventory.Warehouse",
                    "Code WarehouseCode, Name WarehouseName",
                    "WarehouseId Id"
                );
                var SalesOrderJoin = new JoinTable(
                    "Sales.SalesOrder",
                    "OrderNumber SalesOrderCode",
                    "SalesOrderId Id"
                );

               
                var SalesPersonJoin = new JoinTable(
                    "Sales.SalesPerson",
                    "Code SalesPersonCode, Name SalesPersonName",
                    "SalesPersonId Id"
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

                var paymentTermJoin = new JoinTable(
                    "Accounting.PaymentTerm",
                    "Code PaymentTermCode, Name PaymentTermName",
                    "PaymentTermId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        supplierJoin,
                        branchJoin,
                        currencyJoin,
                        WarehouseJoin,
                        SalesOrderJoin,
                        SalesPersonJoin,
                        paymentTermJoin
                    },
                    queryOptions
                );

                var invoicesResult = await _dapper.QueryList<PurchaseInvoiceReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!invoicesResult.Succeeded)
                    return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Fail(invoicesResult.Errors);

                var invoices = invoicesResult.Result?.ToList() ?? new List<PurchaseInvoiceReturnSearchDto>();

                return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Success(invoices);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}