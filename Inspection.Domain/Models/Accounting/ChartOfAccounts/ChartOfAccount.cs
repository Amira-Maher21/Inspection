using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.ChartOfAccounts
{
    [Table("ChartOfAccount")]
    public class ChartOfAccount : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public long? ParentAccountId { get; private set; }
        public bool IsMain { get; private set; }
        public long Level { get; private set; }

        public string AccountTypeCode { get; private set; } = string.Empty;
        public AccountType AccountType { get; private set; } = null!;

        public long? CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;

        public long? CostUnitId { get; private set; }
        public CostUnit CostUnit { get; private set; } = null!;

        public long? CostCenterId { get; private set; }
        public CostCenter CostCenter { get; private set; } = null!;

        public bool IsCostCenterRequired { get; private set; }
        public bool IsCostUnitRequired { get; private set; }
        public bool IsDisable { get; private set; }
        public bool IsControlAccount { get; private set; }
        public bool IsReconciliationAccount { get; private set; }
        public bool IsCashAccount { get; private set; }
        public bool IsBankAccount { get; private set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public void SetLevel(long level)
        {
            Level = level;
        }
    }
}