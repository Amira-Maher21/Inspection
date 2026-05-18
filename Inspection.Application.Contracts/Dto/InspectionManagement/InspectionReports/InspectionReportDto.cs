using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports
{
    public class InspectionReportDto
    {
        public Guid Id { get; set; }
        public Guid InspectionOrderId { get; set; }
        public string Summary { get; set; } = default!;
        public string? ReportUrl { get; set; }
        public string? QRCodeImagePath { get; set; }
        public DateTime GeneratedAt { get; set; }
    }

}
