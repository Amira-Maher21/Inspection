using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.Payment.CashPayments
{
    public class CashPaymentLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent
        public long CashPaymentId { get; set; }
        public CashPayment CashPayment { get; set; } = null!;

        // Payment Method
        public long PaymentModeId { get; private set; }
        public ModeOfPayment ModeOfPayment { get; private set; } = null!;

        // Account (comes from Payment Mode)
        public long AccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; } = null!;

        // Amounts
        public decimal Amount { get; private set; }
        public decimal? FeesAmount { get; private set; }

        // Reference
        public string? ReferenceNumber { get; private set; }
        public DateTime? ReferenceDate { get; private set; }

        // Cheque تفاصيل الشيك
        public string? ChequeNumber { get; private set; }
        public DateTime? ChequeDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        public long? BankId { get; private set; }
        public Bank? Bank { get; private set; }

        // Costing (Project / Cost Control)
        public long? CostCenterId { get; private set; }
        public CostCenter? CostCenter { get; private set; }
        public long? CostUnitId { get; private set; }
        public CostUnit? CostUnit { get; private set; }
        public long? OperationId { get; private set; }
        public Operation? Operation { get; private set; }
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

        // Notes
        public string? Notes { get; private set; }
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}