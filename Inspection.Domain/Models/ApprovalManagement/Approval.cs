using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;

namespace Inspection.Domain.Models.ApprovalManagement
{
    public class Approval : IRootEntity
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = null!;
        public long CompanyId { get; set; }
        public string ScreenId { get; set; } = null!;
        public Screen_Code Screen { get; private set; } = null!;

        public bool? Active { get; set; }
        public string? WorkFlowTitle { get; set; }
        public virtual ICollection<Approval_Delegation> Approval_Delegations { get; set; } = new List<Approval_Delegation>();
        public virtual ICollection<Approval_d> Approval_ds { get; set; } = new List<Approval_d>();
    }
}