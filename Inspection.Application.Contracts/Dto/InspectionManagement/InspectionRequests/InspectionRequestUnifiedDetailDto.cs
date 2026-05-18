namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class InspectionRequestUnifiedDetailDto
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public decimal Quantity { get; set; }
        public long InspectionMethodId { get; set; }
        public long InspectionRequestId { get; set; }
        public string? Tenant_ID { get; set; }
        public bool? IsSubcontractor { get; set; }
    }

}
