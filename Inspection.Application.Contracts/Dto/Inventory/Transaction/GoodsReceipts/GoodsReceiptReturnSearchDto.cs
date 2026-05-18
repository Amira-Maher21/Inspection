namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptReturnSearchDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public long? BranchId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }

        public long WarehouseId { get; set; }
        public string? WarehouseCode { get; set; }
        public string? WarehouseName { get; set; }


        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        //public List<GoodsReceiptLineReturnSearchDto> GoodsReceiptLines { get; set; }
        //    = new();
    }
}
