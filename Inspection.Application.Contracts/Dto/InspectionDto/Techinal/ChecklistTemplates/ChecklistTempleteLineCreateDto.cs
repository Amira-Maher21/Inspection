namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTempleteLineCreateDto
    {
        public long ChecklistTemplateId { get; set; }
        public int DisplayOrder { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string ItemText { get; set; } = string.Empty;



    }
}
