using Inspection.Domain.Enums.Inspection.Technical.Certificate;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Shared.ApprovalStatus;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.Certificates
{
    public class Certificate : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string CerficateNumber { get; set; } = string.Empty;

        public long? ChekclistId { get; private set; }
        public Checklist Checklist { get; private set; } = null!;
        public long IssuedByEmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public CertificateType CertificateType { get; private set; }
        public DateTime IssueDate { get; private set; }
        public Period Period { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public string? Remarks { get; private set; }
        public CertificateDocumentStatus DocumentStatus { get; private set; }
        public ApprovalStatus ApprovalStatus { get; private set; }


        // series 
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}