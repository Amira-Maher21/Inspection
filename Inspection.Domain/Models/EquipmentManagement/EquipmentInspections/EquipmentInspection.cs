using Inspection.Domain.Enums;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspection : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }

        //public Guid EquipmentId { get; set; }
        //public Equipment Equipment { get; set; } = default!;

        //public Guid InspectionOrderId { get; set; }
        //public InspectionOrder InspectionOrder { get; set; } = default!;

        public string ConditionNotes { get; set; } = default!;
        public bool IsOperational { get; set; }
        public DateTime InspectedAt { get; set; } = DateTime.UtcNow;
        public InspectionResult Result { get; set; }

        public string? Tenant_ID { get; set; }
    }

}
