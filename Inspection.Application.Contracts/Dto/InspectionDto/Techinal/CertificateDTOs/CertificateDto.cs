using Inspection.Domain.Enums.Inspection.Technical.Certificate;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs
{
    public class CertificateDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string CerficateNumber { get; set; } = string.Empty;

        public long? ChekclistId { get; set; }
        public long IssuedByEmployeeId { get; set; }

        public CertificateType CertificateType { get; set; }
        public DateTime IssueDate { get; set; }
        public Period Period { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Remarks { get; set; }
        public CertificateDocumentStatus DocumentStatus { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        // series 
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}