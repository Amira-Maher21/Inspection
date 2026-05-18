namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateEquipmentDto
    {
        public Guid? Id { get; set; }
        public long EquipmentId { get; set; }
        public string? EquipmentName { get; set; }
        public string? EquipmentCondition { get; set; }
        public string? InspectionResult { get; set; }
        public string? Notes { get; set; }
        public string Tenant_ID { get; set; }

    }

}
