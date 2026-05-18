using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptQuery : QueryObjectBase<GoodsReceiptReturnSearchDto>
    {
        public GoodsReceiptQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }
        public override async Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                // ===== Master =====
                var tableName = "Inventory.GoodsReceipt";

                var selectFields = new[]
                  {
                    "Id",
                    "CompanyId",
                    "BranchId",
                    "WarehouseId",
                    "GoodsReceiptNo",
                    "GoodsReceiptDate",
                    "Notes",
                    "Posting",
                    "Tenant_ID",
                     "SeriesId",
                    "RunningNumber",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };
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
                    new List<JoinTable>
                    {
                branchJoin,
                warehouseJoin
                     },
                    queryOptions
                );

                var masterResult =
                    await _dapper.QueryList<GoodsReceiptReturnSearchDto>(
                        queryData.QueryString!,
                        queryData.Parameters!.ToDictionary()
                    );

                if (!masterResult.Succeeded)
                    return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Fail(masterResult.Errors);

                var masters = masterResult.Result.ToList();

                if (!masters.Any())
                    return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Success(masters);

                //        var linesSql = @"
                //    SELECT
                //        GRL.Id,
                //        GRL.GoodsReceiptId,

                //        GRL.ItemId,
                //        I.Code  AS ItemCode,
                //        I.Name  AS ItemName,

                //        GRL.WarehouseLocationId,
                //        WL.Code AS WarehouseLocationCode,
                //        WL.Name AS WarehouseLocationName,

                //        GRL.UomId,
                //        U.Code  AS UomCode,
                //        U.Name  AS UomName,

                //        GRL.Quantity,
                //        GRL.UnitCost,
                //        GRL.TotalCost,
                //        GRL.Description,

                //        GRL.In_User,
                //        GRL.In_Date,
                //        GRL.Mod_User,
                //        GRL.Mod_Date
                //    FROM Inventory.GoodsReceiptLine GRL
                //    INNER JOIN Inventory.Item I 
                //        ON GRL.ItemId = I.Id
                //    LEFT JOIN Inventory.WarehouseLocation WL 
                //        ON GRL.WarehouseLocationId = WL.Id
                //    INNER JOIN Inventory.UnitOfMeasure U 
                //        ON GRL.UomId = U.Id
                //    WHERE GRL.GoodsReceiptId IN @GoodsReceiptIds
                //";

                //  var parameters = new Dictionary<string, object>
                //{
                //    { "GoodsReceiptIds", masters.Select(x => x.Id).ToArray() }
                //};

                //var linesResult =
                //    await _dapper.QueryList<GoodsReceiptLineReturnSearchDto>(
                //        //linesSql,
                //        parameters
                //    );

                //if (!linesResult.Succeeded)
                //    return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Fail(linesResult.Errors);

                //    var lookup =
                //        linesResult.Result
                //            .GroupBy(l => l.GoodsReceiptId)
                //            .ToDictionary(g => g.Key, g => g.ToList());

                //    foreach (var receipt in masters)
                //    {
                //        receipt.GoodsReceiptLines =
                //            lookup.TryGetValue(receipt.Id, out var lines)
                //                ? lines
                //                : new List<GoodsReceiptLineReturnSearchDto>();
                //    }

                return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Success(masters);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}