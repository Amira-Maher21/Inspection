using Inspection.Domain.Enums.Inspection.Technical.Certificate;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs
{
    public class CertificateCreateDto
    {
        public long CompanyId { get; set; }
        //public string CerficateNumber { get; set; } = string.Empty;

        public long? ChekclistId { get; set; }
        public long IssuedByEmployeeId { get; set; }

        public CertificateType CertificateType { get; set; }
        public DateTime IssueDate { get; set; }
        public Period Period { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Remarks { get; set; }
        public CertificateDocumentStatus DocumentStatus { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}