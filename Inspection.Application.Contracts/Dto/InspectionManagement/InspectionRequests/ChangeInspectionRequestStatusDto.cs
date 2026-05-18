using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class ChangeInspectionRequestStatusDto
    {
        public long Id { get; set; }
        public InspectionRequestStatus NewStatus { get; set; }
    }
}
