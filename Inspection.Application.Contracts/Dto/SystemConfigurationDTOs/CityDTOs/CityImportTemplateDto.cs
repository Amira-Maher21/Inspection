namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs
{
    public class CityImportTemplateDto
    {
        //[ExcelIgnore]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}