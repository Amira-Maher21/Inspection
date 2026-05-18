namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class DashboardAlertDto
    {
        public string RequestNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string AlertType { get; set; }
        public int Days { get; set; }
    }

}
