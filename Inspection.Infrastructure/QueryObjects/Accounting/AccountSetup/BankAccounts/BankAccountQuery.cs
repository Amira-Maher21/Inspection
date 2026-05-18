using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.BankAccounts
{
    public class BankAccountQuery : QueryObjectBase<BankAccountReturnSearchDto>
    {
        public BankAccountQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.BankAccount";

                var selectFields = new[]
                  {
                    "Id",
                    "BankId",
                    "Tenant_ID",
                    "BankAccountNumber",
                    "IBAN",
                    "AccountType",
                    "Address",
                    "ContactPerson",
                    "CurrencyId",
                    "IsCompanyAccount",
                    "ChartOfAccountId",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                var fromJoin = new NDS.Shared.Application.DataQuery.JoinTable(
                       "Accounting.Bank",
                       "Code BankCode, Name BankName",
                       "BankId Id"
               );


                var toJoin = new NDS.Shared.Application.DataQuery.JoinTable(
                       "Sec.Currency",
                       "Code CurrencyCode, Name CurrencyName",
                       "CurrencyId Id"
               );

                var toJoinChartOfAccount = new NDS.Shared.Application.DataQuery.JoinTable(
                       "Accounting.ChartOfAccount",
                       "AccountCode ChartOfAccountCode, AccountName ChartOfAccountName",
                       "ChartOfAccountId Id"
               );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
               tableName,
               string.Join(", ", selectFields),
               new List<JoinTable> { fromJoin, toJoin, toJoinChartOfAccount },
               queryOptions
               );



                var queryResult = await _dapper.QueryList<BankAccountReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );


                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BankAccountReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



        public override Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
