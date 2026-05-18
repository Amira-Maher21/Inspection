using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptDto
    {
        public long Id { get; set; }

        public string GoodsReceiptNo { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; set; }

        public long WarehouseId { get; set; }

        public DateTime GoodsReceiptDate { get; set; }

        public string Notes { get; set; }
        public PostingEnum Posting { get; set; }


        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public List<GoodsReceiptLineDto> GoodsReceiptLines { get; set; } = new List<GoodsReceiptLineDto>();


    }
}
