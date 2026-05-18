using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetTransactions
{
    public class AssetTransactionQuery : QueryObjectBase<AssetTransactionReturnSearchDto>
    {
        public AssetTransactionQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetTransaction";

                var selectFields = new[]
                {
                    "Id",
                    "FixedAssetId",
                    "TransactionType",
                    "TransactionDate",
                    "ReferenceId",
                    "ReferenceType",
                    "Notes",
                    "Tenant_ID"
                };

                var fixedAssetJoin = new JoinTable(
                    "Accounting.FixedAsset",
                    "Code  FixedAssetCode, Name  FixedAssetName",
                    "FixedAssetId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { fixedAssetJoin },
                    queryOptions
                );

                var result = await _dapper.QueryList<AssetTransactionReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
