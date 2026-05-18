using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Inspection.Technical.Certificate;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs
{
    public class CertificateReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string CerficateNumber { get; set; } = string.Empty;

        public long? ChekclistId { get; set; }
        public EquipmentStatus ChecklistStatus { get; set; }
        public string ChecklistNumber { get; set; } = string.Empty;
        public long? EquipmentId { get; set; }
        public long IssuedByEmployeeId { get; set; }

        public CertificateType CertificateType { get; set; }
        public DateTime IssueDate { get; set; }
        public Period Period { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Remarks { get; set; }
        public CertificateDocumentStatus DocumentStatus { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public ChecklistDto? Checklist { get; set; }

    }
}