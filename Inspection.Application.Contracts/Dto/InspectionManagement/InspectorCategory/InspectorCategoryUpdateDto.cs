namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory
{
    public class InspectorCategoryUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}