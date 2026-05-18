namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails
{
    public class JobOrderLinesDto
    {
        // Identity
        public long Id { get; set; }
        public long JobOrderId { get; set; }

        // Item Information
        public long ItemId { get; set; }
        public string ItemName { get; set; }

        // Inspection Method
        public long InspectionMethodId { get; set; }
        public string InspectionMethodName { get; set; }

        // Inspector Information
        public long InspectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Scheduling
        public DateTime ScheduledFromTime { get; set; }
        public DateTime ScheduledToTime { get; set; }

        // Quantities
        public decimal PlannedQuantity { get; set; }
        public decimal CompletedQuantity { get; set; }

        // Remarks
        public string? Remarks { get; set; }

        // Audit Information
        public string In_User { get; set; }
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}