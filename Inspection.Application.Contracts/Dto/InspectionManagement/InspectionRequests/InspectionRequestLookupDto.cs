using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests
{
    public class InspectionRequestLookupDto
    {
        public long Id { get; set; }
        public string RequestNumber { get; set; }
        public string DisplayText { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}