namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup
{
    public class WarehouseDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long? BranchId { get; set; }
        public bool AllowNegativeStock { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }

        public string Address { get; set; } = string.Empty;
        public long? ResponsibleEmployeeId { get; set; }
        public long? InventoryAccountId { get; set; }


        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;



        //company id
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
