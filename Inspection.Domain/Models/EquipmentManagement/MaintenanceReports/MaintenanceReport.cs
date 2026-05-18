using Inspection.Domain.Models.EquipmentManagement.Equipments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.EquipmentManagement.MaintenanceReports
{
    public class MaintenanceReport : IRootEntity//, ITenantEntity
    {
        public Guid Id { get; set; }

        //public Guid EquipmentId { get; set; }
        //public Equipment Equipment { get; set; } = default!;

        public DateTime MaintenanceDate { get; set; }
        public string PerformedBy { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public string? FileUrl { get; set; }

       // public string? Tenant_ID { get; set; }
    }

}
