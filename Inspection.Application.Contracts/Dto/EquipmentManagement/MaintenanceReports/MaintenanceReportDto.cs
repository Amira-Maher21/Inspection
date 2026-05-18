using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports
{
    public class MaintenanceReportDto
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; } = default!;
        public DateTime MaintenanceDate { get; set; }
        public string PerformedBy { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public string? FileUrl { get; set; }
    }

}
