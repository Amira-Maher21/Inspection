namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateSearchReturnDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long EquipmentTypeId { get; set; }
        public string EquipmentTypeCode { get; set; } = string.Empty;
        public string EquipmentTypeName { get; set; } = string.Empty;

        public long StandardId { get; set; }
        public string StandardCode { get; set; } = string.Empty;
        public string StandardName { get; set; }

        public int Version { get; set; }
        public bool Disabled { get; set; }

        public long CompanyId { get; private set; }

        public long? SeriesId { get; set; }
        public string ChecklistTemplateNumber { get; set; }
        public int RunningNumber { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
