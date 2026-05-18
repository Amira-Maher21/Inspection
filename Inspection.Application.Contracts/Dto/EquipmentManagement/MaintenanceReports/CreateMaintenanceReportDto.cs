using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports
{
    public class CreateMaintenanceReportDto
    {
        public Guid EquipmentId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string PerformedBy { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public string? FileUrl { get; set; }
    }

}
