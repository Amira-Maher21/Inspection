using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules
{
    public class UpdateMaintenanceScheduleDto
    {
        public DateTime ScheduledDate { get; set; }
        public bool IsCompleted { get; set; }
        public string? Notes { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
    }

}
