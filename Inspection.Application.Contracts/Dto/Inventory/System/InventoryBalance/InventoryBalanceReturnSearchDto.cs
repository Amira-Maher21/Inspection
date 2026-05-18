namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance
{
    public class InventoryBalanceReturnSearchDto
    {
        public long Id { get; set; }

        public long? ItemId { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }

        public long WarehouseId { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;

        public long BaseUoMId { get; set; }
        public string UoMCode { get; set; } = string.Empty;
        public string UoMName { get; set; } = string.Empty;

        public decimal Quantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal AverageCost { get; set; }

        public long? WarehouseLocationId { get; set; }
        public string? LocationCode { get; set; }
        public string? LocationName { get; set; }

        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}