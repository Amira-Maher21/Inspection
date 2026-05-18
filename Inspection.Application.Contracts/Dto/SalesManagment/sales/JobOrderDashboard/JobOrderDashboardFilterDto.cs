using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDashboard
{
    public class JobOrderDashboardFilterDto
    {
        public long? CustomerId { get; set; }
        public SalesQuotationStatus? ApprovalStatus { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
