using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCategory;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories
{
    public class AssetCategoryReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public long AssetAccountId { get; set; }
        public string AssetAccountCode { get; set; } = string.Empty;
        public string AssetAccountName { get; set; } = string.Empty;

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

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
