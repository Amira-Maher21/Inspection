using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptImportTemplateDto
    {
        public long CompanyId { get; set; }

        public string BranchCode { get; set; } = string.Empty;
        public string WarehouseCode { get; set; } = string.Empty;

        public DateTime GoodsReceiptDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum Posting { get; set; }
    }
}