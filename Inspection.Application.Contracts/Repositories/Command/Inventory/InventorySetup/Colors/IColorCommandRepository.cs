using Inspection.Domain.Models.Inventory.InventorySetup.Colors;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Colors
{
    public interface IColorCommandRepository : ICommandRepository<Color>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
