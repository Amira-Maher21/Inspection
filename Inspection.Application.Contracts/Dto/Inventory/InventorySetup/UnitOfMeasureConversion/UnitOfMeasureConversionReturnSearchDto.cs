namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion
{
    public class UnitOfMeasureConversionReturnSearchDto
    {
        public long Id { get; set; }


        public long FromUoMId { get; set; }
        public string FromUoMCode { get; set; } = string.Empty;
        public string FromUoMName { get; set; } = string.Empty;


        public long ToUoMId { get; set; }
        public string ToUoMCode { get; set; } = string.Empty;
        public string ToUoMName { get; set; } = string.Empty;


        public decimal ConversionFactor { get; set; }


        public string Tenant_ID { get; set; } = string.Empty;


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
