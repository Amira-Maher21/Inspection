using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{

    public class EquipmentsMoreInformationTemplateDetail : ITenantEntity, IRootEntity
    {
        [Key]
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        [ForeignKey("EquipmentsMoreInformationTemplates")]
        public long EquipmentsMoreInformationTemplateId { get; set; }
        public EquipmentsMoreInformationTemplate EquipmentsMoreInformationTemplates { get; set; }

        public string Tenant_ID { get; set; }
    }
}
