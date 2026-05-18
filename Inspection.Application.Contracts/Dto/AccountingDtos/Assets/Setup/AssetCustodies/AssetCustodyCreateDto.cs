using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies.AssetCustodyLines;
using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies
{
    public class AssetCustodyCreateDto
    {
        public long CompanyId { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Notes { get; set; }

        public AssetCustodyDocumentStatus DocumentStatus { get; set; } = AssetCustodyDocumentStatus.Draft;
        public List<AssetCustodyLineCreateDto> AssetCustodyLines { get; set; } = new();
    }
}
