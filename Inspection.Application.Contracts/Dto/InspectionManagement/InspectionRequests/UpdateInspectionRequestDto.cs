using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class UpdateInspectionRequestDto
    {
        public long Id { get; set; }

        public long? CompanyId { get; set; }

        public DateTime RequestDate { get; set; }

        [Required]
        public long CustomerId { get; set; }

        public long? LocationId { get; set; }
        public long? ContactPersonId { get; set; }
        public long? CustomerProjectId { get; set; }
        public long? InspectionTypeId { get; set; }

        public DateTime? RequestedInspectionDate { get; set; }

        public InspectionDocumentStatus DocumentStatus { get; set; }
        public InspectionApprovalStatus ApprovalStatus { get; set; }

        public string DocumentStatusCancelledDescription { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;

        public IEnumerable<UpdateInspectionRequestLinesDto> InspectionRequestLines { get; set; } = new List<UpdateInspectionRequestLinesDto>();
    }
}