namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long EquipmentTypeId { get; set; }

        public long StandardId { get; set; }
        public int Version { get; set; }
        public bool Disabled { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public long CompanyId { get; private set; }

        public long? SeriesId { get; set; }
        public string ChecklistTemplateNumber { get; set; } = string.Empty;
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<ChecklistTempleteLineDto> ChecklistTemplateLines { get; set; } = new List<ChecklistTempleteLineDto>();

    }
}
