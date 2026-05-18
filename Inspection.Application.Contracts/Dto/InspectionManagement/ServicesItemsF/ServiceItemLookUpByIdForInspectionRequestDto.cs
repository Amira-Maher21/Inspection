using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF
{
    public class ServiceItemLookUpByIdForInspectionRequestDto
    {
        [Key]
        public long Id { get; set; }

        public string Itemtitle { get; set; }

        public string Itemcode { get; set; }

        public string? SubcontractorName { get; set; }
        public bool? IsSubcontractor { get; set; }
        public long? InspectionMethodId { get; set; }
        public string? InspectionMethodName { get; set; }
    }
}
