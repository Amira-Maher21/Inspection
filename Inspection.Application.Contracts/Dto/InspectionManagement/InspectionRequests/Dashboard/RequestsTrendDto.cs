namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class RequestsTrendDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Submitted { get; set; }
        public int Closed { get; set; }
    }
}
