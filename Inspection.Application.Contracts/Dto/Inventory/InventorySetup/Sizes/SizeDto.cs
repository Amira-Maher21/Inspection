namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes
{
    public class SizeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
