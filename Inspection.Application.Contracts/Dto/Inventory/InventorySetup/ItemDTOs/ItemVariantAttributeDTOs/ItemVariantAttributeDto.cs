namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs
{
    public class ItemVariantAttributeDto
    {
        //public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? SKU { get; set; }
        //public string ItemGroup { get; set; } = string.Empty;
        public decimal? UnitPrice { get; set; }

        public List<long> AttributeValueIds { get; set; } = new();
    }
}
