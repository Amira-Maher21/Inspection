using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates
{
    public class InspectionChecklistMoreInformationTemplate : ITenantEntity, IRootEntity
    {
        [Key]
        public long Id { get; set; }


        [ForeignKey("EquipmentTypes")]
        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentTypes { get; set; }

        //public string series { get; set; }
        public ICollection<InspectionChecklistMoreInformationTemplateDetail>? InspectionChecklistMoreInformationTemplateDetails { get; set; }
        public string Tenant_ID { get; set; }
    }
}
