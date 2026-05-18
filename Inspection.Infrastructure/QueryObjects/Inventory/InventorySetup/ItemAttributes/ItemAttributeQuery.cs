using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.ItemAttributes
{
    public class ItemAttributeQuery : QueryObjectBase<ItemAttributeReturnSearchDto>
    {
        public ItemAttributeQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.ItemAttribute";
                string fields = @"
                    [Id],
                    [Tenant_ID],
                    [AttributeName],
                    [In_User],
                    [In_Date],
                    [Mod_User],
                    [Mod_Date]";

                //var joins = new List<JoinTable>
                //{
                //     new JoinTable(
                //         "DMS.DocumentShare",
                //         "ShareToken",
                //         "DocumentShareId Id"
                //     )
                //};

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    //joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<ItemAttributeReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}