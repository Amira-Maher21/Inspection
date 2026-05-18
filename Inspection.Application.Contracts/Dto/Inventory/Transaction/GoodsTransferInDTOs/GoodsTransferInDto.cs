using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs.GoodsTransferInLineDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs
{
    public class GoodsTransferInDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string GoodsTransferInNumber { get; set; } = string.Empty;

        public long BranchId { get; set; }
        public long GoodsTransferOutId { get; set; }
        public long? WareHouseId { get; set; }

        public DateTime GoodsTransferInDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<GoodsTransferInLineDto> GoodsTransferInLines { get; set; } = new();
    }
}
