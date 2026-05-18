namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs.ItemAttributeValueDTOs
{
    public class ItemAttributeValueDto
    {
        public long Id { get; set; }
        public long ItemAttributeId { get; set; }
        public string AttributeValue { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}