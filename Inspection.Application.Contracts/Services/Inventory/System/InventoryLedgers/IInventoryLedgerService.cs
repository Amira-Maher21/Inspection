using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.System.InventoryLedgers
{
    public interface IInventoryLedgerService
    {
        Task<ReturnBase<InventoryLedgerDto>> Create(InventoryLedgerCreateDto createDto);
        Task<ReturnBase<InventoryLedgerDto>> Update(InventoryLedgerUpdateDto updateDto);
        Task<ReturnBase<InventoryLedgerDto>> Delete(long id);
        Task<ReturnBase<InventoryLedgerDto>> GetById(long id);
        Task<InventoryLedger?> GetByItemAsync(long itemId, long warehouseId, long? warehouseLocationId);
        Task<ReturnBase<IEnumerable<InventoryLedgerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        // new 
        Task<InventoryLedger?> GetLastEntryAsync(long itemId, long warehouseId, long? warehouseLocationId);

        Task<List<InventoryLedger>> GetEntriesForItem(long itemId, long warehouseId, long? warehouseLocationId);

        Task MarkAsCancelled(long id);

        Task UpdateBalanceOnly(long id, decimal balance);

        Task<List<InventoryLedger>> GetByReferenceDocumentId(long referenceDocumentId);
    }
}