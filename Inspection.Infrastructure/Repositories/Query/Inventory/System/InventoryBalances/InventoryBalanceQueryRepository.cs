using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryBalances;
using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using Inspection.Infrastructure.QueryObjects.Inventory.System.InventoryBalances;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.System.InventoryBalances
{
    public class InventoryBalanceQueryRepository : QueryRepositoryBase<InventoryBalance>, IInventoryBalanceQueryRepository
    {
        public InventoryBalanceQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<InventoryBalance>>> GetAll()
        {
            var result = await _context.Set<InventoryBalance>().AsNoTracking().ToListAsync();
            return ReturnBase<List<InventoryBalance>>.Success(result);
        }

        public async Task<InventoryBalance?> GetById(long id)
        {
            return await _context.Set<InventoryBalance>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var InventoryBalanceRepository = new InventoryBalanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await InventoryBalanceRepository.Query(sqlQueryOptions);
        }

        public async Task<InventoryBalance?> GetByKey(long itemId, long warehouseId, long? locationId)
        {
            return await _context.Set<InventoryBalance>().FirstOrDefaultAsync(x =>
                x.ItemId == itemId &&
                x.WarehouseId == warehouseId &&
                x.WarehouseLocationId == locationId
            );
        }
    }
}