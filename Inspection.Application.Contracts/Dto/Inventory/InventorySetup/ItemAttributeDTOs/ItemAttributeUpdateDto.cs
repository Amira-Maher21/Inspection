using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs.ItemAttributeValueDTOs;

namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs
{
    public class ItemAttributeUpdateDto
    {
        public long Id { get; set; }
        public string AttributeName { get; set; } = string.Empty;

        public List<ItemAttributeValueUpdateDto> ItemAttributeValues { get; set; } = new List<ItemAttributeValueUpdateDto>();
    }
}
