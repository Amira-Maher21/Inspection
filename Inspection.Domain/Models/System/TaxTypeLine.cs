using Inspection.Domain.Enums.System.Taxs.DocumentDirections;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.System.Taxes;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.System
{
    public class TaxTypeLine : IRootEntity, IAuditable
    {
        public long Id { get; set; }

        public long TaxTypeId { get; set; }
        public TaxType? TaxType { get; set; }

        public DocumentDirection DocumentDirection { get; set; }

        public long ChartOfAccountId { get; set; }
        public ChartOfAccount ChartOfAccount { get; set; }

        public decimal? RecoverablePercentage { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
