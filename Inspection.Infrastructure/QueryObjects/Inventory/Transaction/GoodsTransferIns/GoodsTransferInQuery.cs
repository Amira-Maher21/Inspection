using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsTransferIns
{
    public class GoodsTransferInQuery : QueryObjectBase<GoodsTransferInReturnSearchDto>
    {
        public GoodsTransferInQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.GoodsTransferIn";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "GoodsTransferInNumber",
                    "BranchId",
                    "GoodsTransferOutId",
                    "WareHouseId",
                    "GoodsTransferInDate",
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

                var goodsTransferOutJoin = new JoinTable
                    ("Inventory.GoodsTransferOut",
                    "GoodsTransferOutNumber GoodsTransferOutNumber",
                    "GoodsTransferOutId Id");

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
                        goodsTransferOutJoin,
                        wareHouseJoin,

                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<GoodsTransferInReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}