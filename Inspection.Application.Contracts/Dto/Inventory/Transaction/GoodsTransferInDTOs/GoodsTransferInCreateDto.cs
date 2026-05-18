using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs.GoodsTransferInLineDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs
{
    public class GoodsTransferInCreateDto
    {
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public long GoodsTransferOutId { get; set; }
        public long? WareHouseId { get; set; }

        public DateTime GoodsTransferInDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public List<GoodsTransferInLineCreateDto> GoodsTransferInLines { get; set; } = new();
    }
}
