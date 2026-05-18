using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Colors
{
    internal class ColorQuery : QueryObjectBase<ColorDto>
    {
        public ColorQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ColorDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inventory.Color";
                string fields = "[Id], [Name],[Code], [Tenant_ID], [HexCode]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<ColorDto>(query.QueryString!, query.Parameters!.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ColorDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ColorDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ColorDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ColorDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ColorDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
