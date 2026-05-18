using Inspection.Domain.Models.HRManagement.JobRequests;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.HRManagement.JobAdvertisements
{
    public class JobAdvertisement : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public long JobRequestId { get; set; }
        public JobRequest JobRequest { get; set; } = default!;
        public string Platform { get; set; } = default!; 
        public string Url { get; set; } = default!;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public string? Tenant_ID { get; set; }
    }
}
