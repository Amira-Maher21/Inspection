using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentTypes
{
    public class EquipmentType : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("EquipmentCategorys")]
        public long EquipmentCategoryId { get; set; }
        public EquipmentCategory EquipmentCategorys { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;
    }
}
