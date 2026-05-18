using Inspection.Domain.Enums.ChecklistLines;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
namespace Inspection.Domain.Models.Inspection.Techinal.ChecklistLines
{
    public class ChecklistLine : IRootEntity, IAuditable
    {
        public long Id { get; private set; }
        public long ChecklistId { get; set; }
        public Checklist Checklist { get; set; } = null!;

        public ChecklistTemplateLine ChecklistTemplateLine { get; set; } = null!;
        public long ChecklistTemplateLineId { get; set; }


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
