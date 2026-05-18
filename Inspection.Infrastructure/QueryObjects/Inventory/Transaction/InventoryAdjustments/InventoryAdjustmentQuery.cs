using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentQuery : QueryObjectBase<InventoryAdjustmentReturnSearchDto>
    {
        public InventoryAdjustmentQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.InventoryAdjustment";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "InventoryAdjustmentNumber",
                    "BranchId",
                    "WareHouseId",
                    "InventoryAdjustmentDate",
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

                // Joins
                var branchJoin = new JoinTable
                    ("Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id");

                var wareHouseJoin = new JoinTable
                    ("Inventory.Warehouse",
                    "Code WareHouseCode, Name WareHouseName",
                    "WareHouseId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                        branchJoin,
                        wareHouseJoin,

                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<InventoryAdjustmentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}