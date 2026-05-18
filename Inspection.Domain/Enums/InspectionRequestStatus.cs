using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums
{
    public class ChangeInspectionRequestStatus
    {
        public InspectionRequestStatus Status { get; set; }
    }
    public enum InspectionRequestStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Cancelled = 3
    }


}
