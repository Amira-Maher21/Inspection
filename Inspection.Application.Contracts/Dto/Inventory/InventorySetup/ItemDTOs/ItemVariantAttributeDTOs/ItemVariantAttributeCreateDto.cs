namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs
{
    public class ItemVariantAttributeCreateDto
    {
        public long ItemId { get; set; }

        public List<VariantAttributeInput> Attributes { get; set; } = new();
    }

    public class VariantAttributeInput
    {
        public long AttributeId { get; set; }
        public List<long> ItemAttributeValueIds { get; set; } = new();
    }
}