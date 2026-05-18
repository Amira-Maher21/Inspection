namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs
{
    public class InspectionMethodUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}