namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents
{
    public class AssetAccountingEventCreateDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string AssetEventType { get; set; } = string.Empty;
        public string SourceModule { get; set; } = string.Empty;
        public bool IsReversible { get; set; }
        public bool Disabled { get; set; }


    }
}
