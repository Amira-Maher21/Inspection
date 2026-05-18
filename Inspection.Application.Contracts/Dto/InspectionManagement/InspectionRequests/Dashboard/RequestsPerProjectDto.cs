namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class RequestsPerProjectDto
    {
        public long? ProjectId { get; set; }
        public string ProjectName { get; set; }

        public int Total { get; set; }

        public int Submitted { get; set; }
        public int InProgress { get; set; }
        public int Scheduled { get; set; }
        public int Closed { get; set; }
        public int Cancelled { get; set; }
    }

}
