using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{
    public class InspectionChecklistMoreInformationTemplateDetail : ITenantEntity, IRootEntity
    {
        [Key]
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        [ForeignKey("InspectionChecklistMoreInformationTemplates")]
        public long InspectionChecklistMoreInformationTemplateId { get; set; }
        public InspectionChecklistMoreInformationTemplate InspectionChecklistMoreInformationTemplates { get; set; }

        public string Tenant_ID { get; set; }
    }
}
