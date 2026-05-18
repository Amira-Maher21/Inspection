using Microsoft.EntityFrameworkCore;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Domain.Models.InspectionManagement.ServicesItems
{
    public class ServiceItem : IRootEntity, ITenantEntity
    {


        [Key]
        public long Id { get; set; }
        public string Itemtitle { get; set; }
        public string Itemcode { get; set; }

        [Precision(18, 2)]
        public decimal Itemprice { get; set; }

        public string series { get; set; }

        public string Tenant_ID { get; set; }
        public string? SubcontractorName { get; set; }
        public bool? IsSubcontractor { get; set; }
        public long? InspectionMethodId { get; set; }
    }
}
