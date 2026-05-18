using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.ApprovalManagement
{
    public class Approval_d : ITenantEntity
    {
        public string Tenant_ID { get; set; } = string.Empty;

        public long IDScrAproval { get; set; }

        public int RecordID { get; set; }

        public string Approval_title { get; set; } = null!;

        public long User_CodeId { get; set; }
        public User_Code User { get; private set; } = null!;

        public bool HasCondition { get; set; }

        public decimal? From_Val { get; set; }

        public decimal? To_Val { get; set; }

        public bool Deactivate { get; set; }

        public DateTime? To_Date { get; set; }

        public virtual Approval IDScrAprovalNavigation { get; set; } = null!;
    }
}
