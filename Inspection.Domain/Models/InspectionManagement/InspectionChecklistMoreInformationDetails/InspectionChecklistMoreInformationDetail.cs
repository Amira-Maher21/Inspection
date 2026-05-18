using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails
{

    public class InspectionChecklistMoreInformationDetail : ITenantEntity, IRootEntity
    {
        [Key]
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        [ForeignKey("InspectionChecklistMoreInformations")]
        public long InspectionChecklistMoreInformationId { get; set; }
        public InspectionChecklistMoreInformation InspectionChecklistMoreInformations { get; set; }

        public string Tenant_ID { get; set; }
    }
}

