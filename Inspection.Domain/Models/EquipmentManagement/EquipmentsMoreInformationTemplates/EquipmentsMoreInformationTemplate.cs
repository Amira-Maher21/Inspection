using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates
{

    public class EquipmentsMoreInformationTemplate : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }


        [ForeignKey("EquipmentTypes")]
        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentTypes { get; set; }



        //public string series { get; set; }
        public ICollection<EquipmentsMoreInformationTemplateDetail>? EquipmentsMoreInformationTemplateDetails { get; set; }
        public string Tenant_ID { get; set; }

    }
}