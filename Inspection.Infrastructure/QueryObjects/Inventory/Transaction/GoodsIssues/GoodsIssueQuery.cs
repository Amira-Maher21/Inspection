using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueQuery : QueryObjectBase<GoodsIssueReturnSearchDto>
    {
        public GoodsIssueQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.GoodsIssue";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "WarehouseId",
                    "GoodsIssueNo",
                    "GoodsIssueDate",
                    "Posting",
                    "ApprovalStatus",
                    "DocumentStatus",
                    "Notes",
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

                var warehouseJoin = new JoinTable(
                    "Inventory.Warehouse",
                    "Code WarehouseCode, Name WarehouseName",
                    "WarehouseId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { branchJoin, warehouseJoin },
                    queryOptions
                );

                var goodsIssuesResult = await _dapper.QueryList<GoodsIssueReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!goodsIssuesResult.Succeeded)
                    return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Fail(goodsIssuesResult.Errors);

                var goodsIssues = goodsIssuesResult.Result?.ToList() ?? new List<GoodsIssueReturnSearchDto>();

                return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Success(goodsIssues);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}