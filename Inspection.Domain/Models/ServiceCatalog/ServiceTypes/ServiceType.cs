using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.ServiceCatalog.ServiceTypes
{
    public class ServiceType : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }

        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        //public ICollection<ChecklistTemplate> ChecklistTemplates { get; set; } = new List<ChecklistTemplate>();
        //public ICollection<InspectionOrder> InspectionOrders { get; set; } = new List<InspectionOrder>();
        public string? Tenant_ID { get; set; }

    }
}
