
namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs
{
    public class AssetGroupCreateDto
    {
        public long CompanyId { get; set; }
        public long AssetCategoryId { get; set; }

        public string? GroupCode { get; set; }
        public string? GroupName { get; set; }
        public bool IsLeaf { get; set; } = true;
        public string? Notes { get; set; }
    }
}