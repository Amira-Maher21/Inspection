using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetLocations
{
    public class AssetLocationQuery : QueryObjectBase<AssetLocationReturnSearchDto>
    {
        public AssetLocationQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetLocation";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "LocationCode",
                    "LocationName",
                    "IsLeaf",
                    "ParentLocationId",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };



                // Joins
                var assetLocationJoin = new JoinTable
                    ("Accounting.AssetLocation",
                    "LocationCode ParentLocationCode, LocationName ParentLocationName",
                    "ParentLocationId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                                assetLocationJoin,
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<AssetLocationReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}