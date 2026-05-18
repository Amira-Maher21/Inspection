namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF
{
    public class InspectionRequestSubcontractorDetailDto
    {
        public long Id { get; set; }

        public long ServiceItemId { get; set; }


        public decimal Quantity { get; set; }

        public long InspectionMethodId { get; set; }//came from serviceitem


        public long InspectionRequestId { get; set; }
        public string Tenant_ID { get; set; }
        public bool? IsSubcontractor { get; set; }
        public string? SubcontractorName { get; set; }

    }
}
