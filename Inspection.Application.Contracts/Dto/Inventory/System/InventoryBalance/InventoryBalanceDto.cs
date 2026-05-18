namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance
{
    public class InventoryBalanceDto
    {
        public long Id { get; set; }
        public long? ItemId { get; set; }
        public long WarehouseId { get; set; }
        public long BaseUoMId { get; set; }
        public decimal Quantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal AverageCost { get; set; }
        public long? WarehouseLocationId { get; set; }

        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
