using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs.GoodsTransferOutLineDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs
{
    public class GoodsTransferOutCreateDto
    {
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public long WareHouseFromId { get; set; }
        public long? WareHouseId { get; set; }

        public DateTime GoodsTransferOutDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public List<GoodsTransferOutLineCreateDto> GoodsTransferOutLines { get; set; } = new();
    }
}
