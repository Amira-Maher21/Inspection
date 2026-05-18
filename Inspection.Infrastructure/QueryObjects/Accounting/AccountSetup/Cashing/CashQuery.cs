using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Cashing
{
    public class CashQuery : QueryObjectBase<CashReturnSearchDto>
    {
        public CashQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.Cash";

                var selectFields = new[]
                {
                    "Id",
                    "Code",
                    "Name",
                    "Description",
                    "CompanyId",
                    "Tenant_ID",
                    "BranchId",
                    "CurrencyId",
                    "CashOnHandAccountId"
                };

                // Branch Join
                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id"
                );

                // Currency Join
                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id"
                );

                // Chart Of Account Join
                var accountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode CashAccountCode, AccountName CashAccountName",
                    "CashOnHandAccountId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { branchJoin, currencyJoin, accountJoin },
                    queryOptions
                );

                return await _dapper.QueryList<CashReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter)
            => throw new System.NotImplementedException();

        public override Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters)
            => throw new System.NotImplementedException();
    }
}
