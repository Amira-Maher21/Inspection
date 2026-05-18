namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateImportTemplateDto
    {
        public string Name { get; set; } = string.Empty;
        public long EquipmentTypeCode { get; set; }

        public long StandardCode { get; set; }
        public int Version { get; set; }
        public bool Disabled { get; set; }
        public long CompanyCode { get; private set; }
        // public string CodePattern { get; set; }
        //public string ChecklistTemplateNumber { get; set; }
        //public int RunningNumber { get; set; }
    }
}
