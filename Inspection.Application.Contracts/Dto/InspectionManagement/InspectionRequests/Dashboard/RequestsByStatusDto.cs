namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class RequestsByStatusDto
    {
        public string Status { get; set; }
        public int Count { get; set; } = 0;
    }
}
