namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs
{
    public class InspectorGetListDto
    {

        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? InspectorCategoryCode { get; set; }
        public string? InspectorCategoryName { get; set; }
    }
}
