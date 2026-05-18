using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryCostLayers;
using Inspection.Domain.Models.Inventory.System;
using Inspection.Infrastructure.QueryObjects.Inventory.System.InventoryCostLayers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.System
{
    public class InventoryCostLayerQueryRepository : QueryRepositoryBase<InventoryCostLayer>, IInventoryCostLayerQueryRepository
    {
        public InventoryCostLayerQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<InventoryCostLayer?> GetById(long id)
        {
            return await _context.Set<InventoryCostLayer>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CurrencyQueryRepository = new InventoryCostLayerQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CurrencyQueryRepository.Query(sqlQueryOptions);
        }
        public async Task<InventoryCostLayer?> GetByKey(long itemId, long warehouseId)
        {
            return await _context.Set<InventoryCostLayer>().FirstOrDefaultAsync(x =>
                x.ItemId == itemId &&
                x.WarehouseId == warehouseId
            );
        }
    }
}