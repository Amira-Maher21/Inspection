using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms
{
    public class PaymentTerm : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        public string Code { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;
        public int DaysDue { get; private set; }
        public decimal? DiscountPercentage { get; private set; }
        public int? DaysDiscount { get; private set; }
        public string Description { get; private set; } = string.Empty;
        //  tanent
        public string Tenant_ID { get; set; } = string.Empty;
        //company id
        public long CompanyId { get; set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
