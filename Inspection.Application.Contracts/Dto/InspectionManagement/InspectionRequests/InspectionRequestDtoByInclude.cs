using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class InspectionRequestDtoByInclude
    {
        public long Id { get; set; }

        public string? Tenant_ID { get; set; }
        public long? CompanyId { get; set; }

        public string RequestNumber { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }

        // FK IDs
        public long CustomerId { get; set; }
        public long? LocationId { get; set; }
        public long? ContactPersonId { get; set; }
        public long? CustomerProjectId { get; set; }
        public long? InspectionTypeId { get; set; }
        public long? SeriesId { get; set; }

        public int RunningNumber { get; set; }

        public DateTime RequestedInspectionDate { get; set; }

        // Status
        public InspectionDocumentStatus DocumentStatus { get; set; }
        public InspectionApprovalStatus ApprovalStatus { get; set; }
        public string? DocumentStatusCancelledDescription { get; set; }
        public string? Remarks { get; set; }

        // Lookup Names (optional)
        public string? CustomerName { get; set; }
        public string? LocationName { get; set; }
        public string? ContactPersonName { get; set; }
        public string? CustomerProjectName { get; set; }
        public string? InspectionTypeName { get; set; }

        // Children
        public IEnumerable<InspectionRequestLinesDto> InspectionRequestLines { get; set; }
            = Enumerable.Empty<InspectionRequestLinesDto>();
    }
}