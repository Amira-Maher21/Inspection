using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Payments.CashTransfers
{
    public class CashTransferQuery : QueryObjectBase<CashTransferReturnSearchDto>
    {
        public CashTransferQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.CashTransfer";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "TransferNumber",
                    "BranchId",
                    "FiscalYearId",
                    "ChartOfAccountFromId",
                    "ChartOfAccountToId",
                    "ModeOfPaymentFromId",
                    "ModeOfPaymentToId",
                    "CurrencyId",
                    "TransferDate",
                    "Amount",
                    "IsInTransit",
                    "Posting",
                    "Notes",
                    "ReferenceNumber",
                    "ReferenceDate",
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

                var chartOfAccountFromJoin = new JoinTable
                     ("Accounting.ChartOfAccount",
                     "AccountCode ChartOfAccountFromCode, AccountName ChartOfAccountFromName",
                     "ChartOfAccountFromId Id");

                var chartOfAccountToJoin = new JoinTable
                     ("Accounting.ChartOfAccount",
                     "AccountCode ChartOfAccountToCode, AccountName ChartOfAccountToName",
                     "ChartOfAccountToId Id");


                var modeOfPaymentFromJoin = new JoinTable
                    ("Accounting.ModeOfPayment",
                    "Name ModeOfPaymentFromName",
                    "ModeOfPaymentFromId Id");

                var modeOfPaymentToJoin = new JoinTable
                    ("Accounting.ModeOfPayment",
                    "Name ModeOfPaymentToName",
                    "ModeOfPaymentToId Id");

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
                        chartOfAccountFromJoin,
                        chartOfAccountToJoin,
                        modeOfPaymentFromJoin,
                        modeOfPaymentToJoin,
                        currencyJoin
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<CashTransferReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<CashTransferReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashTransferReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}