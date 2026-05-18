namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion
{
    public class UnitOfMeasureConversionDto
    {
        public long Id { get; set; }
        public long FromUoMId { get; set; }
        public long ToUoMId { get; set; }
        public decimal ConversionFactor { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
