using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.ChartOfAccounts
{
    public class ChartOfAccountSelectQuery : QueryObjectBase<ChartOfAccountSelectQueryDto>
    {
        public ChartOfAccountSelectQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.ChartOfAccount";
                string fields = "[Id],[AccountCode],[AccountName],[ParentAccountId],[AccountTypeCode]";

                queryOptions.Filters ??= new List<string[]>();

                var accountTypeFilters = queryOptions.Filters
                   .Where(f => f.Length >= 3 && f[0] == "AccountTypeCode")
                   .ToList();

                string accountTypeCondition = "";
                List<string> accountTypes = new List<string>();

                if (accountTypeFilters.Any())
                {
                    accountTypes = accountTypeFilters
                        .Select(f => f[2].Trim())
                        .ToList();

                    accountTypeCondition = " AND AccountTypeCode IN @AccountTypeCodes";

                    foreach (var filter in accountTypeFilters)
                    {
                        queryOptions.Filters.Remove(filter);
                    }

                }

                // SQL
                string sqlQuery = $"SELECT {fields} FROM {tableName} WHERE Tenant_ID = @TenantId {accountTypeCondition}";

                // Parameters
                var parameters = new Dictionary<string, object>
                    {
                        { "@TenantId", _tenantResolver.GetTenantName() }
                    };

                if (accountTypes.Any())
                {
                    parameters.Add("@AccountTypeCodes", accountTypes);
                }

                var queryResult = await _dapper.QueryList<ChartOfAccountSelectQueryDto>(sqlQuery, parameters);

                return ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
