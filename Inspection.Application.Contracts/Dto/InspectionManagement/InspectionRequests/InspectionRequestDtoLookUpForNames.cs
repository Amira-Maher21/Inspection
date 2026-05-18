using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class InspectionRequestDtoLookUpForNames
    {
        public long Id { get; set; }
        public string RequestNumber { get; set; }
        public long CustomerId { get; set; }
        public InspectionDocumentStatus DocumentStatus { get; set; }
    }
}
