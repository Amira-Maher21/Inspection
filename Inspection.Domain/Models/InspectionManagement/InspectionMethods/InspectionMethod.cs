using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.InspectionManagement.InspectionMethods
{
    public class InspectionMethod : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public string Name { get; private set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}