using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums
{
    public enum SalesOrderApprovalStatus
    {
        Initialized = 1,
        New = 2,
        Approved = 3,
        Rejected = 4,
        Returned = 5,
        Hold = 6,
        Delegated = 7,
        Completed = 8,

    }
}
