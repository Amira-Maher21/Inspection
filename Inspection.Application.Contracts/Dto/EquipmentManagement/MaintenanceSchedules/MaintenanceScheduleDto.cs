using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules
{
    public class MaintenanceScheduleDto
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; } = default!;
        public DateTime ScheduledDate { get; set; }
        public bool IsCompleted { get; set; }
        public string? Notes { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public string? TechnicalName { get; set; }
    }

}
