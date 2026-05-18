using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOutQuery : QueryObjectBase<GoodsTransferOutReturnSearchDto>
    {
        public GoodsTransferOutQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.GoodsTransferOut";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "GoodsTransferOutNumber",
                    "BranchId",
                    "WareHouseFromId",
                    "WareHouseId",
                    "GoodsTransferOutDate",
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

                var wareHouseFromJoin = new JoinTable
                    ("Inventory.Warehouse",
                    "Code WareHouseFromCode, Name WareHouseFromName",
                    "WareHouseFromId Id");

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
                        wareHouseFromJoin,
                        wareHouseJoin,

                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<GoodsTransferOutReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}