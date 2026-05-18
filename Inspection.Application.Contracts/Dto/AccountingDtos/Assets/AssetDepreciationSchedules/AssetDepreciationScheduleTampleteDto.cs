namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleTampleteDto
    {
        public string AssetCode { get; set; } = string.Empty;
        public int PeriodYear { get; set; }
        public int PeriodMonth { get; set; }
        public decimal DepreciationAmount { get; set; }
        public bool IsPosted { get; set; }
    }
}
