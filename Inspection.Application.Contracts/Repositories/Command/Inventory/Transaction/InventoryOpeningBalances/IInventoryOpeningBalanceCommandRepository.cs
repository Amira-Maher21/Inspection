using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryOpeningBalances
{

    public interface IInventoryOpeningBalanceCommandRepository : ICommandRepository<InventoryOpeningBalance>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteInventoryOpeningBalanceLinesByIds(List<long> ids);
    }
}