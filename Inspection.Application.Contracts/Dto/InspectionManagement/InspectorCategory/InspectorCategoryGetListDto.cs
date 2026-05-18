namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory
{
    public class InspectorCategoryGetListDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
    }
}