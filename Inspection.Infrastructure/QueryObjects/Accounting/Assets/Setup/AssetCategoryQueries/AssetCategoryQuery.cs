using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetCategoryQueries
{
    public class AssetCategoryQuery : QueryObjectBase<AssetCategoryReturnSearchDto>
    {
        public AssetCategoryQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetCategory";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "CategoryCode",
                    "CategoryName",
                    "AssetAccountId",
                    "AccumulatedDepreciationAccountId",
                    "DepreciationExpenseAccountId",
                    "AssetDisposalAccountId",
                    "GainOnDisposalAccountId",
                    "LossOnDisposalAccountId",
                    "RevaluationSurplusAccountId",
                    "ImpairmentLossAccountId",
                    "DefaultDepreciationMethod",
                    "DefaultUsefulLifeMonths",
                    "DefaultResidualValuePct",
                    "Notes",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };



                // Joins
                var AssetAccountJoin = new JoinTable
                    ("Accounting.ChartOfAccount",
                    "AccountCode AssetAccountCode, AccountName AssetAccountName",
                    "AssetAccountId Id");


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                                AssetAccountJoin,
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<AssetCategoryReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}