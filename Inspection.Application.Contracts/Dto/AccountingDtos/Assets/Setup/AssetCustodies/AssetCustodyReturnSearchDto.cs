using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies.AssetCustodyLines;
using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies
{
    public class AssetCustodyReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Notes { get; set; }

        public AssetCustodyDocumentStatus DocumentStatus { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<AssetCustodyLineDto> AssetCustodyLines { get; set; } = null!;
    }
}