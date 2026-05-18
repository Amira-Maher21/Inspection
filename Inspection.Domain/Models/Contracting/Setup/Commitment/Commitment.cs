using Inspection.Domain.Enums.Contracting.Setup.Commitments;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Contracting.Setup.Commitment
{
    public class Commitment : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public CommitmentType CommitmentType { get; set; }
        public string DocumentNo { get; set; } = string.Empty;

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public DateTime CommitmentDate { get; set; }
        public CommitmentDocumentStatus DocumentStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual ICollection<CommitmentLine> CommitmentLines { get; set; } = null!;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
