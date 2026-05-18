using System.ComponentModel.DataAnnotations;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF
{
    public class InspectionRequestLinesDtoByInclude
    {
        [Key]
        public long Id { get; set; }

        public long ItemId { get; set; }
        public string? ItemName { get; set; }

        public long InspectionMethodId { get; set; }
        public string? InspectionMethodName { get; set; }

        public long InspectionRequestId { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public bool? IsSubcontractor { get; set; }

        public InspectionRequestLinesStatus Status { get; set; }
    }
}