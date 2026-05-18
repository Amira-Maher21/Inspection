
namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs
{
    public class AssetGroupUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long AssetCategoryId { get; set; }

        public string? GroupCode { get; set; }
        public string? GroupName { get; set; }
        public bool IsLeaf { get; set; } = true;
        public string? Notes { get; set; }
    }
}