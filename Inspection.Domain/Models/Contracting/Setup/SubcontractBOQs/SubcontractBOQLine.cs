using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs
{
    public class SubcontractBOQLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent
        public long SubcontractBOQId { get; set; }
        public SubcontractBOQ SubcontractBOQ { get; set; } = null!;

        public string BOQItemCode { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string UnitId { get; private set; } = string.Empty;
        public decimal Quantity { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Amount { get; private set; }

        public long? WBSId { get; private set; }
        public WBS? WBS { get; private set; }

        public long? CostCodeId { get; private set; }
        public CostCode? CostCode { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}