using NDS.Shared.Domain.Contracts;

namespace Inspection.Domain.Models.ApprovalManagement
{
    public class Approval_Delegation : IRootEntity
    {
        public long ID { get; set; }

        public long IDScrAproval { get; set; }

        public long User_CodeId { get; set; }

        public long User_CodeId_Delegated { get; set; }

        public DateTime? To_Date { get; set; }

        public virtual Approval IDScrAprovalNavigation { get; set; } = null!;
    }
}
