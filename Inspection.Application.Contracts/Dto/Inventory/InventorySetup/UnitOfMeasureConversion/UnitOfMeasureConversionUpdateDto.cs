namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion
{
    public class UnitOfMeasureConversionUpdateDto
    {
        public long Id { get; set; }
        public long FromUoMId { get; set; }
        public long ToUoMId { get; set; }
        public decimal ConversionFactor { get; set; }


    }
}
