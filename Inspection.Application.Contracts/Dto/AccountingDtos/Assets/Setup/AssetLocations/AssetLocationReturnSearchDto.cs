namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations
{
    public class AssetLocationReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public long? ParentLocationId { get; set; }
        public string ParentLocationName { get; set; } = string.Empty;
        public string ParentLocationCode { get; set; } = string.Empty;
        public string LocationCode { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
        public bool IsLeaf { get; set; } = true;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}