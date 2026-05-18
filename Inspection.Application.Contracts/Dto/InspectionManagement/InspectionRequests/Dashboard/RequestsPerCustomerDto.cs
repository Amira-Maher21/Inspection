namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard
{
    public class RequestsPerCustomerDto
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long Count { get; set; }
    }
}
