using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums
{
    public class ChangeInspectionApprovalStatus
    {
        public InspectionApprovalStatus ApprovalStatus { get; set; }
    }
    public enum InspectionApprovalStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4
    }
}
