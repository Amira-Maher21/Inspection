namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateDto
    {
        public long Id { get; set; }

        public string CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

        public long InspectionChecklistId { get; set; }

        public string Series { get; set; }

        public string Tenant_ID { get; set; }
    }

}
