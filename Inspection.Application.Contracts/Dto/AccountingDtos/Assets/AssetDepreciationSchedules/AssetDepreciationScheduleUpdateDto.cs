namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleUpdateDto
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public int PeriodYear { get; set; }
        public int PeriodMonth { get; set; }
        public decimal DepreciationAmount { get; set; }
        public bool IsPosted { get; set; }

    }
}
