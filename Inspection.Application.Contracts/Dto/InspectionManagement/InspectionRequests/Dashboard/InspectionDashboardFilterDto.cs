using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class InspectionDashboardFilterDto
    {

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public long? CustomerId { get; set; }
        public long? ProjectId { get; set; }
        //public long? InspectorId { get; set; }

        //public bool? QuotationIssued { get; set; }
        public InspectionDocumentStatus? Status { get; set; }

        //public bool? QuotationIssued { get; set; }


        public bool UseRequestedInspectionDate { get; set; }


    }
}
