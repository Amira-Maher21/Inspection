using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies.AssetCustodyLines
{
    public class AssetCustodyLineCreateDto
    {
        public long FixedAssetId { get; set; }
        public AssetCustodyLineCustodyType custodyType { get; set; } = AssetCustodyLineCustodyType.Issue;
        public long? FromEmployeeId { get; set; }
        public long? ToEmployeeId { get; set; }
        public long? FromOperationId { get; set; }
        public long? ToOperationId { get; set; }
        public long? FromCostCenterId { get; set; }
        public long? ToCostCenterId { get; set; }
        public long? FromCostCodeId { get; set; }
        public long? ToCostCodeId { get; set; }
        public DateTime CustodyStartDate { get; set; }
        public DateTime? CustodyEndDate { get; set; }
        public string? HandoverDocumentUrl { get; set; }
        public bool IsAcknowledged { get; set; }
        public DateTime? AcknowledgedDate { get; set; }
        public AssetCustodyLineDocumentStatus DocumentStatus { get; set; } = AssetCustodyLineDocumentStatus.Draft;
        public string? Notes { get; set; }
    }
}