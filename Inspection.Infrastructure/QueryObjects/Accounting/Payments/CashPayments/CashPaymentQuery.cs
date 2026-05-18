using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Payments.CashPayments
{
    public class CashPaymentQuery : QueryObjectBase<CashPaymentReturnSearchDto>
    {
        public CashPaymentQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.CashPayment";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "ReceiptNumber",
                    "ManualNumber",
                    "BranchId",
                    "FiscalYearId",
                    "AccountId",
                    "CustomerId",
                    "CurrencyId",
                    "TaxTypeId",
                    "Description",
                    "ReceivedFrom",
                    "ReceiptDate",
                    "PostingDate",
                    "TaxPercent ",
                    "TaxAmount",
                    "TotalAmount ",
                    "Posting",
                    "ApprovalStatus",
                    "SeriesId",
                    "RunningNumber",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // Joins
                var branchJoin = new JoinTable("Accounting.Branch", "Code BranchCode, Name BranchName", "BranchId Id");
                var fiscalYearJoin = new JoinTable("Accounting.FiscalYear", "Code FiscalYearCode", "FiscalYearId Id");
                var accountJoin = new JoinTable("Accounting.ChartOfAccount", "AccountCode AccountCode, AccountName AccountName", "AccountId Id");
                var customerJoin = new JoinTable("Accounting.Customer", "Code CustomerCode, Name CustomerName", "CustomerId Id");
                var currencyJoin = new JoinTable("Sec.Currency", "Code CurrencyCode, Name CurrencyName", "CurrencyId Id");
                var taxTypeJoin = new JoinTable("Accounting.TaxType", "Code TaxTypeCode, Name TaxTypeName", "TaxTypeId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                        branchJoin,
                        fiscalYearJoin,
                        accountJoin,
                        customerJoin,
                        currencyJoin,
                        taxTypeJoin
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<CashPaymentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}