
namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs
{
    public class AssetGroupReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long AssetCategoryId { get; set; }
        public string AssetCategoryCode { get; set; } = string.Empty;
        public string AssetCategoryName { get; set; } = string.Empty;

        public string? GroupCode { get; set; }
        public string? GroupName { get; set; }
        public bool IsLeaf { get; set; } = true;
        public string? Notes { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}