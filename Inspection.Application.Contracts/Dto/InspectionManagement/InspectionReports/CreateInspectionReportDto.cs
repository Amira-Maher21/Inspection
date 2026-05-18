using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports
{
    public class CreateInspectionReportDto
    {
        public Guid InspectionOrderId { get; set; }
        public string Summary { get; set; } = default!;
    }


}
