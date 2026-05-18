using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs.ItemAttributeValueDTOs;

namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs
{
    public class ItemAttributeCreateDto
    {
        public string AttributeName { get; set; } = string.Empty;

        public List<ItemAttributeValueCreateDto> ItemAttributeValues { get; set; } = new List<ItemAttributeValueCreateDto>();
    }
}