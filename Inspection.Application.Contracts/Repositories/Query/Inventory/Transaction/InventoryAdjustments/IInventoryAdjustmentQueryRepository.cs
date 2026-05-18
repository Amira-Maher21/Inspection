using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryAdjustments
{
    public interface IInventoryAdjustmentQueryRepository : IQueryRepository<InventoryAdjustment>
    {
        Task<ReturnBase<List<InventoryAdjustment>>> GetAll();
        Task<InventoryAdjustment?> GetById(long id);
        Task<InventoryAdjustment?> GetByInventoryAdjustmentNumber(string inventoryAdjustmentNumber);
        Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}