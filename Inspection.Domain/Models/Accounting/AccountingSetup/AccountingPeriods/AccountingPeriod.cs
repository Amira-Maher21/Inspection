using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods
{
    [Table("AccountingPeriod")]

    public class AccountingPeriod : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; } = null!;
        public string Code { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime LockDate { get; private set; }
        public bool IsClosed { get; private set; } = true;
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}