using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryLedgers
{

    public interface IInventoryLedgerQueryRepository : IQueryRepository<InventoryLedger>
    {
        Task<InventoryLedger?> GetById(long id);
        Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<InventoryLedger?> GetByItemAsync(long itemId, long warehouseId, long? warehouseLocationId);

        Task<decimal> SumOutboundQuantityAsync(long itemId, DateTime from, DateTime to);

        Task<IEnumerable<InventoryLedger>> GetEntriesForItem(
            long itemId,
            long warehouseId,
            long? warehouseLocationId);


        Task<List<InventoryLedger>> GetByReferenceDocumentId(long referenceDocumentId);
    }
}