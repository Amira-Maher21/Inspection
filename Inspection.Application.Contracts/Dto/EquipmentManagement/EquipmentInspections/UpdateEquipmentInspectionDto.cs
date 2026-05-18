using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections
{
    public class UpdateEquipmentInspectionDto
    {
        public string ConditionNotes { get; set; } = default!;
        public bool IsOperational { get; set; }
        public DateTime? InspectedAt { get; set; }
    }

}
