using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleQuery
        : QueryObjectBase<AssetDepreciationScheduleReturnSearchDto>
    {
        public AssetDepreciationScheduleQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.AssetDepreciationSchedule";

                var selectFields = new[]
                {
                    "Id",
                    "AssetId",
                    "PeriodYear",
                    "PeriodMonth",
                    "DepreciationAmount",
                    "IsPosted",
                    "Tenant_ID",


                };

                var fixedAssetJoin = new JoinTable(
                    "Accounting.FixedAsset",
                    "Code  FixedAssetCode, Name  FixedAssetName",
                    "AssetId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { fixedAssetJoin },
                    queryOptions
                );

                var result = await _dapper.QueryList<AssetDepreciationScheduleReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
