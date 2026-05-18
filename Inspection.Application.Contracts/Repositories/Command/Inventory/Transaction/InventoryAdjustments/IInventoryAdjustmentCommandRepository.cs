using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryAdjustments
{
    public interface IInventoryAdjustmentCommandRepository : ICommandRepository<InventoryAdjustment>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteInventoryAdjustmentLinesByIds(List<long> ids);
    }
}