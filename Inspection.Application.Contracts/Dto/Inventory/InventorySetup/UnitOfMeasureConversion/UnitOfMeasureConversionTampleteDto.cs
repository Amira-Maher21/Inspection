namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion
{
    public class UnitOfMeasureConversionTampleteDto
    {
        public long FromUoMId { get; set; }
        public long ToUoMId { get; set; }
        public decimal ConversionFactor { get; set; }
    }
}
