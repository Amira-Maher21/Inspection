namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup
{
    public class WarehouseReturnSearchDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public long? BranchId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }


        public long? InventoryAccountId { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;

        public long? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }


        public long? CityId { get; set; }
        public string? CityCode { get; set; }
        public string? CityName { get; set; }


        public string Address { get; set; } = string.Empty;
        public long? ResponsibleEmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;


        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
