using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections
{
    public class CreateEquipmentInspectionDto
    {
        public Guid EquipmentId { get; set; }
        public Guid InspectionOrderId { get; set; }
        public string ConditionNotes { get; set; } = default!;
        public bool IsOperational { get; set; }
        public DateTime? InspectedAt { get; set; }
    }

}
