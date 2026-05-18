using Inspection.Domain.Enums.ChecklistLines;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists.ChecklistLines
{
    public class ChecklistLineDto
    {
        public long Id { get; set; }
        public long ChecklistId { get; set; }
        public string MeasuredValue { get; set; } = string.Empty;
        public ChecklistLineStatus Status { get; set; }
        public string Remarks { get; set; } = string.Empty;
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
