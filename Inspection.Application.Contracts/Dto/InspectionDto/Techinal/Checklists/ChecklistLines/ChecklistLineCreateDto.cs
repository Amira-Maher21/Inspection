using Inspection.Domain.Enums.ChecklistLines;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists.ChecklistLines
{
    public class ChecklistLineCreateDto
    {
        public long ChecklistId { get; set; }
        public string MeasuredValue { get; set; } = string.Empty;
        public long ChecklistTemplateLineId { get; set; }
        public ChecklistLineStatus Status { get; set; }
        public string Remarks { get; set; } = string.Empty;

    }
}
