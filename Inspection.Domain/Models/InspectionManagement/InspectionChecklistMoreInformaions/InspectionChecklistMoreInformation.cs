using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations
{
    public class InspectionChecklistMoreInformation : ITenantEntity, IRootEntity
    {
        [Key]
        public long Id { get; set; }


        [ForeignKey("EquipmentTypes")]
        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentTypes { get; set; }

        [ForeignKey("InspectionChecklists")]
        public long InspectionChecklistId { get; set; }
        public InspectionChecklist InspectionChecklists { get; set; }

        //public string series { get; set; }
        public ICollection<InspectionChecklistMoreInformationDetail>? InspectionChecklistMoreInformationDetails { get; set; }
        public string Tenant_ID { get; set; }
    }
}
