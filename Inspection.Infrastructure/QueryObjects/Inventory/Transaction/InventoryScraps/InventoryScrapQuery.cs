using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapQuery : QueryObjectBase<InventoryScrapReturnSearchDto>
    {
        public InventoryScrapQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.InventoryScrap";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",

                    "InventoryScrapNumber",
                    "InventoryScrapDate",
                    "Notes",
                    "Posting",
                    "ApprovalStatus",
                    "SeriesId",
                    "RunningNumber",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // ================== JOINS ==================

                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id"
                );



                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        branchJoin,

                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<InventoryScrapReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Fail(result.Errors);

                var data = result.Result?.ToList() ?? new List<InventoryScrapReturnSearchDto>();

                return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}