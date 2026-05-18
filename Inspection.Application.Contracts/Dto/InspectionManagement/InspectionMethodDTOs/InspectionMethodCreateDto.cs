namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs
{
    public class InspectionMethodCreateDto
    {
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}