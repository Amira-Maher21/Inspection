using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetCustodies
{
    internal class AssetCustodyQuery : QueryObjectBase<AssetCustodyReturnSearchDto>
    {
        public AssetCustodyQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try


            {
                string tableName = "Accounting.AssetCustody";
                string fields = "[Id],[Tenant_ID], [CompanyId] ,[DocumentNumber],[DocumentDate],[Notes],[DocumentStatus],[In_User],[In_Date],[Mod_User],[Mod_Date]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<AssetCustodyReturnSearchDto>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
