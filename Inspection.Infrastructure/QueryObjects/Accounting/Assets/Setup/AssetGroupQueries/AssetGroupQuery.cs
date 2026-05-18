using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetGroupQueries
{
    public class AssetGroupQuery : QueryObjectBase<AssetGroupReturnSearchDto>
    {
        public AssetGroupQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }



        public override async Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetGroup";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "AssetCategoryId",
                    "GroupCode",
                    "GroupName",
                    "IsLeaf",
                    "Notes",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };



                //Joins

                var assetCategoryJoin = new JoinTable
                            ("Accounting.AssetCategory",
                            "CategoryCode AssetCategoryCode, CategoryName AssetCategoryName",
                            "AssetCategoryId Id");



                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                                assetCategoryJoin
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<AssetGroupReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
