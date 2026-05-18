namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class LatestInspectionRequestDto
    {
        public string RequestNumber { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }


        public string ProjectName { get; set; }

        public string? LocationName { get; set; }

        public DateTime? RequestedInspectionDate { get; set; }

        public bool QuotationIssued { get; set; }

        public double ChecklistCompletionPercentage { get; set; }
    }

}
