namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTempleteLineUpdateDto
    {
        public long Id { get; set; }
        public long ChecklistTemplateId { get; set; }
        public int DisplayOrder { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string ItemText { get; set; } = string.Empty;



    }
}
