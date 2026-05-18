using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceAdjustment : IAuditable
    {
        public long Id { get; set; }

        public long PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }

        public long ChartOfAccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; }

        public decimal Amount { get; private set; }
        public string? Description { get; private set; }

        public long CostCenterId { get; private set; }
        public CostCenter CostCenter { get; private set; }

        public long CostUnitId { get; private set; }
        public CostUnit CostUnit { get; private set; }

        public long OperationId { get; private set; }
        public Operation Operation { get; private set; }


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


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
