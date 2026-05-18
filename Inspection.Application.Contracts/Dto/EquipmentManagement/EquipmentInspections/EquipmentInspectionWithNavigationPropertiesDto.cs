using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.Equipments;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspectionWithNavigationPropertiesDto
    {
        public EquipmentInspection EquipmentInspections { get; set; } = default!;
        public Equipment Equipments { get; set; } = default!;
        //public InspectionOrder InspectionOrders { get; set; } = default!;
    }
}
