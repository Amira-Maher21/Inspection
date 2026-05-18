using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Items
{
    public interface IItemVariantAttributeQueryRepository : IQueryRepository<ItemVariantAttribute>
    {
        Task<List<ItemVariantGroupDto>> GetByParentItemId(long parentItemId);
        Task<List<ItemVariantAttributeDto>> GetVariants(long itemId);
    }
}