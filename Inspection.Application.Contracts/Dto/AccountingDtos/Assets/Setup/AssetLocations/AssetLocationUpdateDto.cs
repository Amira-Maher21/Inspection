namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations
{
    public class AssetLocationUpdateDto
    {
        public long Id { get; set; }
        public string CompanyId { get; set; } = string.Empty;
        public long? ParentLocationId { get; set; }
        public string LocationCode { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
        public bool IsLeaf { get; set; } = true;
    }
}