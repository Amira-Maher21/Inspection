using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.WarehouseLocations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.WarehouseLocations
{

    public class WarehouseLocationQueryRepository : QueryRepositoryBase<WarehouseLocation>, IWarehouseLocationQueryRepository
    {
        public WarehouseLocationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<WarehouseLocation?> GetById(long id)
        {
            return await _context.Set<WarehouseLocation>().Where(x => x.Id == id).FirstOrDefaultAsync();

        }
        public async Task<WarehouseLocation?> GetByCode(string code)
        {
            return await _context.Set<WarehouseLocation>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }




        public async Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var customerQuery = new WarehouseLocationQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await customerQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Select(SqlQueryOptions sqlQueryOptions)
        {
            var warehouseSelectQuery = new WarehouseLocationSelectQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await warehouseSelectQuery.Query(sqlQueryOptions);
        }

    }

}
