using Inspection.Domain.Models.Inventory.System;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryCostLayers
{
    public interface IInventoryCostLayerCommandRepository : ICommandRepository<InventoryCostLayer>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}