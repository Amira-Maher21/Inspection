namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs
{
    public class ItemVariantGroupDto
    {
        public long ItemId { get; set; }
        public List<long> AttributeValueIds { get; set; } = new();
    }
}
