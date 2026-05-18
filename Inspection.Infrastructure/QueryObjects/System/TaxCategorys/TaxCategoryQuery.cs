using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.System.TaxCategorys
{
    internal class TaxCategoryQuery : QueryObjectBase<TaxCategoryDto>
    {
        public TaxCategoryQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.TaxCategory";
                string fields = "[Id], [Name],[Code],[Description] ,[Tenant_ID]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<TaxCategoryDto>(query.QueryString!, query.Parameters!.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<TaxCategoryDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<TaxCategoryDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TaxCategoryDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
