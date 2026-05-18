namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class InspectionDashboardDto
    {

        // KPI Cards
        public int TotalRequests { get; set; }
        public int InProgressRequests { get; set; }
        public int CancelledOrClosedRequests { get; set; }

        public int ScheduledRequests { get; set; }
        public int CompletedRequests { get; set; }


        // Chart
        public List<RequestsByStatusDto> RequestsByStatus { get; set; }

        // Latest Requests Table
        public List<LatestInspectionRequestDto> LatestRequests { get; set; }




        public List<RequestsPerProjectDto> RequestsPerProject { get; set; }

        public List<DashboardAlertDto> Alerts { get; set; }


        public List<RequestsPerCustomerDto> RequestsPerCustomer { get; set; }
        public List<RequestsTrendDto> Trends { get; set; }

        public int PendingSchedulingRequests { get; set; }
        public double RepeatCustomerPercentage { get; set; }

        public int QuotationIssuedRequests { get; set; }
        public int QuotationNotIssuedRequests { get; set; }
        public double QuotationIssuedPercentage { get; set; }

    }
}
