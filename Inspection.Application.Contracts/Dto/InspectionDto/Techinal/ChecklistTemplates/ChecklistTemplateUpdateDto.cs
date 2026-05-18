namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long EquipmentTypeId { get; set; }

        public long StandardId { get; set; }
        public int Version { get; set; }
        public bool Disabled { get; set; }
        public long CompanyId { get; set; }
        public List<ChecklistTempleteLineUpdateDto> ChecklistTemplateLines { get; set; } = new List<ChecklistTempleteLineUpdateDto>();

        // public long? SeriesId { get; set; }
        //public int RunningNumber { get; set; }
        //public string ChecklistTemplateNumber { get; set; }
    }
}
