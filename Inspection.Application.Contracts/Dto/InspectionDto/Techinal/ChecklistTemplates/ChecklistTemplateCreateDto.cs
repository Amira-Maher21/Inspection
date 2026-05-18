namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public long EquipmentTypeId { get; set; }

        public long StandardId { get; set; }
        public int Version { get; set; }
        public bool Disabled { get; set; }
        public long CompanyId { get; set; }
        public List<ChecklistTempleteLineCreateDto> ChecklistTemplateLines { get; set; } = new List<ChecklistTempleteLineCreateDto>();

        // public long? SeriesId { get; set; }
        //public int RunningNumber { get; set; }
        //public string ChecklistTemplateNumber { get; set; }
    }
}