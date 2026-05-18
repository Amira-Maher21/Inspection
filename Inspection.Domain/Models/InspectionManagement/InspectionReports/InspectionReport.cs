using NDS.Shared.Domain.Contracts;

namespace Inspection.Domain.Models.InspectionManagement.InspectionReports
{
    public class InspectionReport : IRootEntity//, ITenantEntity
    {
        public Guid Id { get; set; }
        //public string? Tenant_ID { get; set; }

        //public Guid InspectionOrderId { get; set; }
        //public InspectionOrder InspectionOrder { get; set; } = default!;

        public string Summary { get; set; } = default!;
        public string? ReportUrl { get; set; }
        public string? QRCodeImagePath { get; set; }

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}
