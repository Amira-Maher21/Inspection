using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares
{
    public class EquipmentSoftwareDto
    {
        [Key]
        public long Id { get; set; }
        public long CompanyEquipmentId { get; set; }

        [Required]
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string? Version { get; set; }
        public string? Notes { get; set; }
        public string Tenant_ID { get; set; }

    }
}
