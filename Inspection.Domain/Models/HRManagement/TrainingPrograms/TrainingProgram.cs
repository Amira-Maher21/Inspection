using Inspection.Domain.Enums;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.HRManagement.TrainingPrograms
{
    public class TrainingProgram : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public TrainingType Type { get; set; }
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Supervisor { get; set; } = default!;
        public string? Tenant_ID { get; set; }
    }


}
