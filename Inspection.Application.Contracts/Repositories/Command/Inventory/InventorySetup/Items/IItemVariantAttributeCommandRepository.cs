using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Items
{
    public interface IItemVariantAttributeCommandRepository : ICommandRepository<ItemVariantAttribute>
    {
        Task AddRange(List<ItemVariantAttribute> entities);
    }
}