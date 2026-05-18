using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs.GoodsTransferOutLineDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs
{
    public class GoodsTransferOutReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string GoodsTransferOutNumber { get; set; } = string.Empty;

        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public long WareHouseFromId { get; set; }
        public string WareHouseFromCode { get; set; } = string.Empty;
        public string WareHouseFromName { get; set; } = string.Empty;

        public long? WareHouseId { get; set; }
        public string? WareHouseCode { get; set; }
        public string? WareHouseName { get; set; }

        public DateTime GoodsTransferOutDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<GoodsTransferOutLineDto> GoodsTransferOutLines { get; set; } = new();
    }
}