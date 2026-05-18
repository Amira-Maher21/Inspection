namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTempleteLineDto
    {
        public long Id { get; set; }
        public long ChecklistTemplateId { get; set; }
        public int DisplayOrder { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string ItemText { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

    }
}
