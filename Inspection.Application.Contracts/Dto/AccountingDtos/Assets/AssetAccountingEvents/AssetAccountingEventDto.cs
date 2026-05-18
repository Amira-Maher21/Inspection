namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents
{
    public class AssetAccountingEventDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string AssetEventType { get; set; } = string.Empty;
        public string SourceModule { get; set; } = string.Empty;
        public bool IsReversible { get; set; }
        public bool Disableld { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
