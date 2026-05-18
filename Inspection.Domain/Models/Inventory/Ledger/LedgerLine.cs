using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inventory.Ledger
{
    public class LedgerLine : IAuditable, IRootEntity
    {
        public long Id { get; set; }

        public long LedgerId { get; set; }
        public Ledger Ledger { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
        public long? CustomerId { get; set; }

        public Supplier Supplier { get; set; } = null!;
        public long? SupplierId { get; set; }

        public long? ChartOfAccountId { get; set; }
        public ChartOfAccount? ChartOfAccount { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

        public decimal BaseDebitAmount { get; set; }
        public decimal BaseCreditAmount { get; set; }
        public decimal OfficialDebitAmount { get; set; }
        public decimal OfficialCreditAmount { get; set; }
        public decimal ReportingDebitAmount { get; set; }
        public decimal ReportingCreditAmount { get; set; }

        public long? CostCenterId { get; set; }
        public CostCenter? CostCenter { get; set; }

        public long? CostUnitId { get; set; }
        public CostUnit? CostUnit { get; set; }

        public long? OperationId { get; set; }
        public Operation? Operation { get; set; }

        public long? WBSId { get; private set; }
        public WBS? WBS { get; private set; }

        public long? CostCodeId { get; private set; }
        public CostCode? CostCode { get; private set; }

        public long? ActivityId { get; private set; }
        public Activity? Activity { get; private set; }

        public long? SubcontractBOQId { get; private set; }
        public SubcontractBOQ? SubcontractBOQ { get; private set; }

        public long? ProductionOrderId { get; private set; }
        public ProductionOrder? ProductionOrder { get; private set; }

        public long? BOQLineId { get; private set; }
        public BOQLine? BOQLine { get; private set; }

        // Auditing
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
