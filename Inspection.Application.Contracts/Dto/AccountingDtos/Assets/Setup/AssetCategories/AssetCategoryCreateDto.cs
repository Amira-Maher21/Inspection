using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCategory;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories
{
    public class AssetCategoryCreateDto
    {
        public string CompanyId { get; set; } = string.Empty;
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public long AssetAccountId { get; set; }
        public long AccumulatedDepreciationAccountId { get; set; }
        public long DepreciationExpenseAccountId { get; set; }
        public long? AssetDisposalAccountId { get; set; }
        public long? GainOnDisposalAccountId { get; set; }
        public long? LossOnDisposalAccountId { get; set; }
        public long? RevaluationSurplusAccountId { get; set; }
        public long? ImpairmentLossAccountId { get; set; }
        public DefaultDepreciationMethod DefaultDepreciationMethod { get; set; }
        public int DefaultUsefulLifeMonths { get; set; }
        public decimal? DefaultResidualValuePct { get; set; }
        public string Notes { get; set; } = string.Empty;

    }
}
