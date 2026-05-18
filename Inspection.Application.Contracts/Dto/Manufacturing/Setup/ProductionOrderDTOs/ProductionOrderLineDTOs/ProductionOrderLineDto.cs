namespace Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs.ProductionOrderLineDTOs
{
    public class ProductionOrderLineDto
    {
        public long Id { get; set; }

        public long ProductionOrderId { get; set; }

        public long ItemId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Amount { get; set; }

        public long WBSId { get; set; }
        public long CostCodeId { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}