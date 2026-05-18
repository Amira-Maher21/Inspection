namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleReturnSearchDto
    {
        public long Id { get; set; }

        public long AssetId { get; set; }
        public string FixedAssetCode { get; set; } = string.Empty;
        public string FixedAssetName { get; set; } = string.Empty;

        public int PeriodYear { get; set; }
        public int PeriodMonth { get; set; }

        public decimal DepreciationAmount { get; set; }
        public bool IsPosted { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
    }
}
