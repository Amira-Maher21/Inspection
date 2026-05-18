using System.ComponentModel.DataAnnotations;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF
{
    public class InspectionRequestLinesDto
    {
        public long Id { get; set; }

        public long ItemId { get; set; }

        public long InspectionMethodId { get; set; }

        public long InspectionRequestId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public bool? IsSubcontractor { get; set; }

        public InspectionRequestLinesStatus Status { get; set; }

        public string In_User { get; set; }
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}