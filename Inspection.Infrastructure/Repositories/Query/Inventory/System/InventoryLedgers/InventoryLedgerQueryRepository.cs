using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryLedgers;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using Inspection.Infrastructure.QueryObjects.Inventory.System.InventoryLedgers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.System.InventoryLedgers
{
    public class InventoryLedgerQueryRepository : QueryRepositoryBase<InventoryLedger>, IInventoryLedgerQueryRepository
    {
        public InventoryLedgerQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<InventoryLedger?> GetById(long id)
        {
            return await _context.Set<InventoryLedger>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CurrencyQueryRepository = new InventoryLedgerQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CurrencyQueryRepository.Query(sqlQueryOptions);
        }
        public async Task<InventoryLedger?> GetByItemAsync(long itemId, long warehouseId, long? warehouseLocationId)
        {
            return await _context.Set<InventoryLedger>()
                .Where(l => l.ItemId == itemId
                            && l.WarehouseId == warehouseId
                            && l.WarehouseLocationId == warehouseLocationId)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> SumOutboundQuantityAsync(long itemId, DateTime from, DateTime to)
        {
            return await _context.Set<InventoryLedger>()
                .Where(l => l.ItemId == itemId
                         && l.TransactionDate >= from
                         && l.TransactionDate <= to
                         && l.QuantityOut != null)
                .SumAsync(l => l.QuantityOut ?? 0m);
        }

        public async Task<IEnumerable<InventoryLedger>> GetEntriesForItem(
            long itemId,
            long warehouseId,
            long? warehouseLocationId)
        {
            var query = _context.Set<InventoryLedger>()
                .Where(x =>
                    x.ItemId == itemId &&
                    x.WarehouseId == warehouseId &&
                    x.WarehouseLocationId == warehouseLocationId &&
                    !x.IsDeleted
                );

            return await query
                .OrderBy(x => x.PostingDate)
                .ThenBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<InventoryLedger>> GetByReferenceDocumentId(long referenceDocumentId)
        {
            return await _context.Set<InventoryLedger>()
                .Where(x => x.ReferenceDocumentId == referenceDocumentId && !x.IsDeleted)
                .ToListAsync();
        }
    }
}