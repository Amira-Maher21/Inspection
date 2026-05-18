using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryBalances
{
    public interface IInventoryBalanceCommandRepository : ICommandRepository<InventoryBalance>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}

