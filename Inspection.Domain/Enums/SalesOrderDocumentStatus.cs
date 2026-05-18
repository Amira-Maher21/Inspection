using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums
{
    public enum SalesOrderDocumentStatus
    {
        Draft = 1,
        Confirmed = 2,
        PartiallyDelivered = 3,
        Delivered = 4,
        Invoiced = 5,
        Closed = 6,
        Cancelled = 7,

    }
}
