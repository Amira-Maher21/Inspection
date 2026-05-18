using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonQuery : QueryObjectBase<ScrapReasonReturnSearchDto>
    {
        public ScrapReasonQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.ScrapReason";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "Code",
                    "Name",
                    "ChartOfAccountId",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // ================== JOINS ==================

                var coaJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode ChartOfAccountCode, AccountName ChartOfAccountName",
                    "ChartOfAccountId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        coaJoin
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<ScrapReasonReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Fail(result.Errors);

                var data = result.Result?.ToList() ?? new List<ScrapReasonReturnSearchDto>();

                return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}