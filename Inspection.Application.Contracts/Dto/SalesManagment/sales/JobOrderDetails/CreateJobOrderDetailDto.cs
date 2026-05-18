using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails
{
    public class CreateJobOrderLinesDto
    {

        public long JobOrderId { get; set; }
        public long ItemId { get; set; }
        public long InspectionMethodId { get; set; }
        public long InspectorId { get; set; }

        public DateTime ScheduledFromTime { get; set; }
        public DateTime ScheduledToTime { get; set; }
        public decimal PlannedQuantity { get; set; }
        public decimal CompletedQuantity { get; set; }
        public string? Remarks { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
