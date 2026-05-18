using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories
{
    public class CreateEquipmentAccessoryDto
    {
         public string? Note { get; set; }
        public long CompanyEquipmentId { get; set; }

        [Required]
        public string Description { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }

        public EquipmentAccessoriesStatus Status { get; set; }
        public string Tenant_ID { get; set; }

    }
}
