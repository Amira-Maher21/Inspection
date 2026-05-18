using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys
{

    public class EquipmentCategory : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tenant_ID { get; set; }
         
    }
}
