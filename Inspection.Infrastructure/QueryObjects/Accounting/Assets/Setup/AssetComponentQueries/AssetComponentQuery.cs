using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetComponentQueries
{
    public class AssetComponentQuery : QueryObjectBase<AssetComponentReturnSearchDto>
    {

        public AssetComponentQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetComponent";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "FixedAssetId",
                    "ComponentName",
                    "ComponentCost",
                    "UsefulLifeMonths",
                    "ResidualValue",
                    "DepreciationMethodId",
                    "Notes",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };


                // Joins
                var fixedAssetJoin = new JoinTable
                            ("Accounting.FixedAsset",
                            "Code FixedAssetCode, Name FixedAssetName",
                            "FixedAssetId Id");


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                        fixedAssetJoin,
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<AssetComponentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}



