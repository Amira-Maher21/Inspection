using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF
{
    public class JobOrderIncludeDto
    {
        // Identity
        public long Id { get; set; }
        public string JobOrderNumber { get; set; }

        // Customer Information
        public long? CustomerId { get; set; }
        public string CustomerName { get; set; }

        // Related Documents
        public long? QuotationId { get; set; }
        public string QuotationNo { get; set; }

        public long? InspectionRequestId { get; set; }
        public string InspectionRequestNo { get; set; }

        public long? SalesOrderId { get; set; }
        public string SalesOrderNo { get; set; }

        // Job Order Details
        public DateTime JobOrderDate { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }

        // Location & Site Contact
        public string Location { get; set; }
        public string SiteContactName { get; set; }
        public string SiteContactMobile { get; set; }
        public string SiteContactEmail { get; set; }

        // Remarks
        public string Remarks { get; set; }

        // Series Information
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Status Information
        public JobOrderDocumentStatus DocumentStatus { get; set; }
        public string DocumentStatusCancelledDescription { get; set; }
        public SalesQuotationStatus ApprovalStatus { get; set; }

        // Audit Information
        public string? In_User { get; set; }
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Navigation Properties
        public ICollection<JobOrderLinesDto> JobOrderLines { get; set; } = new List<JobOrderLinesDto>();
    }
}