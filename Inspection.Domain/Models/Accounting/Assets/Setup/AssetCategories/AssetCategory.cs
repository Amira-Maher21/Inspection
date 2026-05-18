using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCategory;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories
{
    public class AssetCategory : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string CategoryCode { get; private set; } = string.Empty;
        public string CategoryName { get; private set; } = string.Empty;

        public long AssetAccountId { get; private set; }
        public ChartOfAccount AssetAccount { get; private set; } = null!;
        public long AccumulatedDepreciationAccountId { get; private set; }
        public ChartOfAccount AccumulatedDepreciationAccount { get; private set; } = null!;
        public long DepreciationExpenseAccountId { get; private set; }
        public ChartOfAccount DepreciationExpenseAccount { get; private set; } = null!;
        public long? AssetDisposalAccountId { get; private set; }
        public ChartOfAccount? AssetDisposalAccount { get; private set; }
        public long? GainOnDisposalAccountId { get; private set; }
        public ChartOfAccount? GainOnDisposalAccount { get; private set; }
        public long? LossOnDisposalAccountId { get; private set; }
        public ChartOfAccount? LossOnDisposalAccount { get; private set; }
        public long? RevaluationSurplusAccountId { get; private set; }
        public ChartOfAccount? RevaluationSurplusAccount { get; private set; }
        public long? ImpairmentLossAccountId { get; private set; }
        public ChartOfAccount? ImpairmentLossAccount { get; private set; }
        public DefaultDepreciationMethod DefaultDepreciationMethod { get; private set; }
        public int DefaultUsefulLifeMonths { get; private set; }
        public decimal? DefaultResidualValuePct { get; private set; }
        public string Notes { get; private set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
