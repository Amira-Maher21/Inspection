namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs
{
    public class BatchDto
    {
        public long Id { get; set; }
        public string BatchNumber { get; set; }

        public long CompanyId { get; set; }
        public long ItemId { get; set; }

        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }


        // Audit 
        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
