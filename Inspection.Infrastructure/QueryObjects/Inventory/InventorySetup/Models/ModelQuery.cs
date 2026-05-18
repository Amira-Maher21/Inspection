using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Models
{
    public class ModelQuery : QueryObjectBase<ModelSearchReturnDto>
    {
        public ModelQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        //public override async Task<ReturnBase<IEnumerable<Model>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {
        //        string tableName = "Model";
        //        string fields = "[Id],[Tenant_ID],[Code],[Name],[Description],[BrandId]";
        //        QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

        //        var result = await this._dapper.QueryList<Model>(query.QueryString!, query.Parameters.ToDictionary());
        //        if (!result.Succeeded)
        //            return ReturnBase<IEnumerable<Model>>.Fail(result.Errors);

        //        return ReturnBase<IEnumerable<Model>>.Success(result.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<Model>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public override async Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Query(
    SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Inventory.Model";

                var selectFields = new[]
                {
            "Id",
            "Code",
            "Name",
            "Description",
            "BrandId",
            "Tenant_ID",
            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                var joinTableName = "Inventory.Brand";
                var joinSelectFields = "Code BrandCode, Name BrandName";
                var joinField = "BrandId Id";

                var joinTable = new JoinTable(
                    joinTableName,
                    joinSelectFields,
                    joinField
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { joinTable },
                    queryOptions
                );

                var queryResult =
                    await _dapper.QueryList<ModelSearchReturnDto>(
                        queryData.QueryString!,
                        queryData.Parameters!.ToDictionary()
                    );

                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ModelSearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

