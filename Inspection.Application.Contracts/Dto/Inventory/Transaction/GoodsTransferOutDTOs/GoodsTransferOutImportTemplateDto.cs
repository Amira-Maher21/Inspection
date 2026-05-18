using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs
{
    public class GoodsTransferOutImportTemplateDto
    {
        public long CompanyId { get; set; }

        //FK
        public string BranchCode { get; set; } = string.Empty;
        public string WareHouseFromCode { get; set; } = string.Empty;
        public string? WareHouseCode { get; set; }

        public DateTime GoodsTransferOutDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}