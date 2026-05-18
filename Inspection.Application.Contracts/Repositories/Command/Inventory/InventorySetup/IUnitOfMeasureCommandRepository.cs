using Inspection.Domain.Models.Inventory.InventorySetup;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup
{
    public interface IUnitOfMeasureCommandRepository : ICommandRepository<UnitOfMeasure>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}

