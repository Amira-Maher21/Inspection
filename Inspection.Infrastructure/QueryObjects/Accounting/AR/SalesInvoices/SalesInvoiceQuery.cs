using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AR.SalesInvoices
{

    public class SalesInvoiceQuery : QueryObjectBase<SalesInvoiceReturnSearchDto>
    {
        public SalesInvoiceQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.SalesInvoice";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "InvoiceNo",
                    "InvoiceDate",
                    "PostingDate",

                    "CustomerId",
                    "SalesOrderId",
                    "GoodsReceiptId",

                    "CurrencyId",
                    "PaymentTermsId",

                    "DocumentStatus",
                    "ApprovalStatus",
                    "IsPosted",
                    "PaymentDuesDate",

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

                var customerJoin = new JoinTable(
                    "Accounting.Customer",
                    "Code CustomerCode, Name CustomerName",
                    "CustomerId Id"
                );

                //var salesOrderJoin = new JoinTable(
                //    "Sales.SalesOrder",
                //    "Code SalesOrderCode, Name SalesOrderName",
                //    "SalesOrderId Id"
                //);

                var BranchJoin = new JoinTable(
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
                    "Code PaymentTermsCode, Name PaymentTermsName",
                    "PaymentTermsId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        customerJoin,
                       BranchJoin,
                        //goodsReceiptJoin,
                        currencyJoin,
                        paymentTermJoin
                    },
                    queryOptions
                );

                var invoicesResult = await _dapper.QueryList<SalesInvoiceReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!invoicesResult.Succeeded)
                    return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Fail(invoicesResult.Errors);

                var invoices = invoicesResult.Result?.ToList()
                               ?? new List<SalesInvoiceReturnSearchDto>();

                if (invoices.Count == 0)
                    return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Success(invoices);





                return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Success(invoices);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}