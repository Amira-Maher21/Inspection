using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.ChartOfAccounts
{
    public class ChartOfAccountQuery : QueryObjectBase<ChartOfAccountReturnSearchDto>
    {
        public ChartOfAccountQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.ChartOfAccount";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "AccountCode",
                    "AccountName",
                    "ParentAccountId",
                    "IsMain",
                    "Level",
                    "AccountTypeCode",
                    "CurrencyId",
                    "CostUnitId",
                    "CostCenterId",
                    "IsCostCenterRequired",
                    "IsCostUnitRequired",
                    "IsDisable",
                    "IsControlAccount",
                    "IsReconciliationAccount",
                    "IsCashAccount",
                    "IsBankAccount"
                };

                // ================== JOINS ==================

                //var parentAccountJoin = new JoinTable(
                //    "ChartOfAccount",
                //    "AccountCode ParentAccountCode, AccountName ParentAccountName",
                //    "ParentAccountId Id"
                //);

                var accountTypeJoin = new JoinTable(
                     "Accounting.AccountType",
                     "AccountTypeName, AccountTypeCode",
                     "AccountTypeCode AccountTypeCode"
                 );

                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code CurrencyCode,Name CurrencyName",
                    "CurrencyId Id"
                );

                var costUnitJoin = new JoinTable(
                    "Accounting.CostUnit",
                    "Code CostUnitCode,Name CostUnitName",
                    "CostUnitId Id"
                );

                var costCenterJoin = new JoinTable(
                    "Accounting.CostCenter",
                    "Code CostCenterCode,Name CostCenterName",
                    "CostCenterId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        //parentAccountJoin,
                        accountTypeJoin,
                        currencyJoin,
                        costUnitJoin,
                        costCenterJoin
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<ChartOfAccountReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
