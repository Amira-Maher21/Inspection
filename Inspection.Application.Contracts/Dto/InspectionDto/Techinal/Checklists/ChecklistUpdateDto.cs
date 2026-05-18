using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists.ChecklistLines;
using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Checklists;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists
{
    public class ChecklistUpdateDto
    {
        public long Id { get; set; }
        public long EquipmentId { get; set; }
        public long InspectorId { get; set; }
        public long ChecklistTemplateId { get; set; }
        public long StandardId { get; set; }
        public long InspectionTypeId { get; set; }
        public EquipmentStatus Status { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public long CompanyId { get; set; }
        public long JoborderId { get; set; }
        public long? JobOrderLineId { get; set; }
        public long CustomerId { get; set; }
        public ChecklistDocStatus DocStatus { get; set; }
        public List<ChecklistLineUpdateDto> ChecklistLines { get; set; } = new List<ChecklistLineUpdateDto>();
    }
}