using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptCreateDto
    {

        public long CompanyId { get; set; }

        public long BranchId { get; set; }

        public long WarehouseId { get; set; }

        public DateTime GoodsReceiptDate { get; set; }

        public string Notes { get; set; }
        public PostingEnum Posting { get; set; }

        public List<GoodsReceiptLineCreateDto> GoodsReceiptLines { get; set; } = new List<GoodsReceiptLineCreateDto>();

    }
}
