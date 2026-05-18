namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup
{
    public class WarehouseUpdateDto
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
        public long CompanyId { get; set; }

    }
}
