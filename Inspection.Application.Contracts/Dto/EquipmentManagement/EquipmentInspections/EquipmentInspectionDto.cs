using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspectionDto
    {
        public long Id { get; set; }
        //public long EquipmentId { get; set; }
        //public string EquipmentName { get; set; } = default!;
        //public long InspectionOrderId { get; set; }

        public string ConditionNotes { get; set; } = default!;
        public bool IsOperational { get; set; }
        public DateTime InspectedAt { get; set; }
        public InspectionResult Result { get; set; }
        public string? Tenant_ID { get; set; }

    }

}
