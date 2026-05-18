using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationSelectQuery : QueryObjectBase<WarehouseLocationSelectDto>
    {
        public WarehouseLocationSelectQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.WarehouseLocation";
                string fields = "[Id], [Code],[Name] ";

                queryOptions.Filters ??= new List<string[]>();


                queryOptions.Filters.Add(new string[]
               {
                         "Tenant_ID", "=",
                         _tenantResolver.GetTenantName()

                   });


                var company = _tenantResolver.GetCommonUserData()?.Company;
                if (!string.IsNullOrEmpty(company))
                {
                    queryOptions.Filters.Add(new string[]
                    {
                            "CompanyId",
                            "=",
                            company
                                });
                }


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", fields),
                     queryOptions
                );

                var queryResult = await _dapper.QueryList<WarehouseLocationSelectDto>(
                        queryData.QueryString!,
                        queryData.Parameters!.ToDictionary()
                    );

                return ReturnBase<IEnumerable<WarehouseLocationSelectDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseLocationSelectDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}