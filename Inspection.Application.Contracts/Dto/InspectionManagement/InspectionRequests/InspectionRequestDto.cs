using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class InspectionRequestDto
    {
        public long Id { get; set; }

        public string RequestNumber { get; set; }

        public string? Tenant_ID { get; set; }
        public long? CompanyId { get; set; }

        public DateTime RequestDate { get; set; }

        // ========================
        // FK IDs (from entity)
        // ========================
        public long CustomerId { get; set; }
        public long? LocationId { get; set; }
        public long? ContactPersonId { get; set; }
        public long? CustomerProjectId { get; set; }
        public long? InspectionTypeId { get; set; }
        public long? SeriesId { get; set; }

        public int RunningNumber { get; set; }

        public DateTime? RequestedInspectionDate { get; set; }

        public InspectionDocumentStatus DocumentStatus { get; set; }
        public InspectionApprovalStatus ApprovalStatus { get; set; }

        public string DocumentStatusCancelledDescription { get; set; }
        public string Remarks { get; set; } = string.Empty;

        // ========================
        // Child Collections
        // ========================
        public IEnumerable<InspectionRequestLinesDto> InspectionRequestLines { get; set; } = new List<InspectionRequestLinesDto>();

        public string In_User { get; set; }
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}