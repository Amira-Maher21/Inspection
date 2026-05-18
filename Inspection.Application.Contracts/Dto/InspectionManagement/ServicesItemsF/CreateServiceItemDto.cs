using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF
{
    public class CreateServiceItemDto
    {
       
        [Required]
        public string Itemtitle { get; set; }
        [Required]
        public string Itemcode { get; set; }
        [Required]
        public decimal Itemprice { get; set; }
        public string series { get; set; }
        public string? SubcontractorName { get; set; }
        public bool? IsSubcontractor { get; set; }
        public long? InspectionMethodId { get; set; }

    }
}
