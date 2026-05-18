namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasure
{
    public class UnitOfMeasureUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsBaseUnit { get; set; }
    }
}
