using Inspection.Domain.Event;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AR.MasterData;
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

namespace Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates
{
    public class JournalEntryTemplateLine : IRootEntity, IAuditable, IPostingLineEntity
    {
        public long Id { get; set; }
        public long JournalEntryTemplateId { get; set; }
        public virtual JournalEntryTemplate JournalEntryTemplate { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
        public long? CustomerId { get; set; }

        public Supplier? Supplier { get; set; } = null!;
        public long? SupplierId { get; set; }

        public long AccountId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public long? CostCenterId { get; set; }
        public virtual CostCenter? CostCenter { get; set; } = null;
        public long? CostUnitId { get; set; }
        public virtual CostUnit? CostUnit { get; set; } = null;
        public long? OperationId { get; set; }
        public virtual Operation? Operation { get; set; } = null;

        public long? ItemWorkId { get; set; }
        // public virtual ItemWork? ItemWork { get; set; } = null;
        public string? Description { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


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
    }

}
