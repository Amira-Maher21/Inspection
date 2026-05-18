namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class InspectionRequestDtoLookUpForRequestDetails
    {


        public long Id { get; set; }
        public string? RequestNumber { get; set; }
        public List<InspectionRequestUnifiedDetailDto> Details { get; set; } = [];

    }
}
