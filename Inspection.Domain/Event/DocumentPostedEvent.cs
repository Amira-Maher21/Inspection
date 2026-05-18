using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Event
{
    public class DocumentPostedEvent : IPostingEvent
    {
        public long DocId { get; }
        public string DocumentCode { get; }
        public string TenantId { get; }
        public string UserId { get; }
        public DateTime OccurredOn { get; }

        public DocumentPostedEvent(
            long docId,
            string documentCode,
            string tenantId,
            string userId)
        {
            DocId = docId;
            DocumentCode = documentCode;
            TenantId = tenantId;
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
