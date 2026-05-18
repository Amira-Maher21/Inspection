using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Payments.DebitNotes
{
    public class DebitNoteQuery : QueryObjectBase<DebitNoteReturnSearchDto>
    {
        public DebitNoteQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.DebitNote";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "DebitNoteNumber",
                    "BranchId",
                    "FiscalYearId",
                    "SalesInvoiceId",
                    "CustomerId",
                    "ChartOfAccountId",
                    "CurrencyId",
                    "Description",
                    "DebitNoteDate",
                    "AdditionalDiscountType",
                    "AdditionalDiscountValue",
                    "AdditionalDiscountAmount",
                    "TotalDiscount",
                    "TaxAmount",
                    "TotalAmount",
                    "Posting",
                    "SeriesId",
                    "RunningNumber",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // Joins
                var branchJoin = new JoinTable
                    ("Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id");

                var fiscalYearJoin = new JoinTable
                    ("Accounting.FiscalYear",
                    "Code FiscalYearCode",
                    "FiscalYearId Id");

                var salesInvoiceJoin = new JoinTable
                    ("Accounting.SalesInvoice",
                    "InvoiceNo InvoiceNumber",
                    "SalesInvoiceId Id");

                var customerJoin = new JoinTable
                     ("Accounting.Customer",
                     "Code CustomerCode, Name CustomerName",
                     "CustomerId Id");

                var chartOfAccountIdJoin = new JoinTable
                     ("Accounting.ChartOfAccount",
                     "AccountCode ChartOfAccountCode, AccountName ChartOfAccountName",
                     "ChartOfAccountId Id");

                var currencyJoin = new JoinTable
                     ("Sec.Currency",
                     "Code CurrencyCode, Name CurrencyName",
                     "CurrencyId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                        branchJoin,
                        fiscalYearJoin,
                        salesInvoiceJoin,
                        customerJoin,
                        chartOfAccountIdJoin,
                        currencyJoin
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<DebitNoteReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}