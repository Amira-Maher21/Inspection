using Inspection.Domain.Enums;
using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories
{
    public class EquipmentAccessory : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }

        [ForeignKey("CompanyEquipments")]
        public long CompanyEquipmentId { get; set; }
        public CompanyEquipment CompanyEquipments { get; set; }
         public string? Note { get; set; }
        //[Required]
        public string Description { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }

        public EquipmentAccessoriesStatus Status { get; set; }

        public string Tenant_ID { get; set; }
    }
}

