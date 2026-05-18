using Inspection.Domain.Enums;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules
{
    public class MaintenanceSchedule : IRootEntity, ITenantEntity
    {
        public Guid Id { get; set; }

        //public Guid EquipmentId { get; set; }
        //public Equipment Equipment { get; set; } = default!;

        public DateTime ScheduledDate { get; set; }
        public DateTime? PerformedDate { get; set; }

        public bool IsCompleted { get; set; } = false;
        public string? Notes { get; set; }
        public int? TechnicianId { get; set; }
        //public User? Technician { get; set; }

        public MaintenanceType MaintenanceType { get; set; } = MaintenanceType.Preventive;

        public string? Tenant_ID { get; set; }
    }

}
