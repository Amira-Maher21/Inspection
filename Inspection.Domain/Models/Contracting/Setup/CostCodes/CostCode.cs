using Inspection.Domain.Models.Contracting.Setup.Divisions;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Contracting.Setup.CostCodes
{


    public class CostCode : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        // Required Fields
        public string CostCodeValue { get; set; } = string.Empty; // CostCode
        public string CostCodeName { get; set; } = string.Empty;

        // FK
        public long DivisionId { get; set; }
        public Division Division { get; set; }

        // Tree Structure
        public long? ParentCostCodeId { get; set; }


        // Leaf
        public bool IsLeaf { get; set; }

        // Multi-tenant
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}