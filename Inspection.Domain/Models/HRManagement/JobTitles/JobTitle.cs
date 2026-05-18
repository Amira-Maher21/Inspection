using Inspection.Domain.Models.HRManagement.Departments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.HRManagement.JobTitles
{
    public class JobTitle : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public long DepartmentId { get; set; }
        public Department Department { get; set; }

        public string? Tenant_ID { get; set; }

    }

}
