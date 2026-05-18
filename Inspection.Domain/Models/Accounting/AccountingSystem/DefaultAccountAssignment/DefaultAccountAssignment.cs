using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;
namespace Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment
{
    [Table("DefaultAccountAssignment")]
    public class DefaultAccountAssignment : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long DefaultAccountGroupID { get; private set; }
        public virtual DefaultAccountGroup DefaultAccountGroup { get; private set; } = null!;
        public long DefaultAccountTypeID { get; private set; }
        public virtual DefaultAccountType DefaultAccountType { get; private set; } = null!;

        public long AccountID { get; private set; }
        public virtual ChartOfAccount ChartOfAccount { get; private set; } = null!;
        public long CurrencyID { get; private set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
