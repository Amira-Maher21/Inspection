namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs.ItemAttributeValueDTOs
{
    public class ItemAttributeValueUpdateDto
    {
        public long Id { get; set; }
        public string AttributeValue { get; set; } = string.Empty;
    }
}