using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports
{
    public class UpdateInspectionReportDto
    {
        public Guid Id { get; set; }
        public string ReportContent { get; set; } = default!;
    }

}
