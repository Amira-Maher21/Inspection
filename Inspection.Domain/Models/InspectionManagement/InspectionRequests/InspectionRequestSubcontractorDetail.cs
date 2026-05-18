using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionRequests
{
    [Table("InspectionRequestSubcontractorDetail", Schema = "Inspection")]
    public class InspectionRequestSubcontractorDetail : ITenantEntity, IRootEntity
    {
        public long Id { get; set; }
        public string? Tenant_ID { get; set; }

        [Required]

        [ForeignKey("ServiceItems")]
        public long ServiceItemId { get; set; }
        public ServiceItem ServiceItems { get; set; }

        public string? SubcontractorName { get; set; }
        public bool? IsSubcontractor { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }

        [Required]
        [ForeignKey("InspectionMethods")]
        public long InspectionMethodId { get; set; }//came from serviceitem
        public InspectionMethod InspectionMethods { get; set; }

        [ForeignKey("InspectionRequest")]
        public long InspectionRequestId { get; set; }
        public InspectionRequest InspectionRequests { get; set; }
    }
}