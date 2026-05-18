namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes
{
    public class InspectionTypeCreateDto
    {
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}