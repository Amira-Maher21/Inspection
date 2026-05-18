namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleDto
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public int PeriodYear { get; set; }
        public int PeriodMonth { get; set; }
        public decimal DepreciationAmount { get; set; }
        public bool IsPosted { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
