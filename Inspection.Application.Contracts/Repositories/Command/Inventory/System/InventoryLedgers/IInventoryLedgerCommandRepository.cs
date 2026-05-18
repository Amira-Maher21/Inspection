using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryLedgers
{
    public interface IInventoryLedgerCommandRepository : ICommandRepository<InventoryLedger>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}