using Inspection.Domain.Enums.DMS.ShareAccessLog;
using Inspection.Domain.Models.DMS.DocumentShares;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.ShareAccessLogs
{
    public class ShareAccessLog : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public DateTime AccessedAt { get; set; }

        public string? AccessIp { get; set; }

        public string? UserAgent { get; set; }


        public ShareAccessLogAction? Action { get; set; }

        public long DocumentShareId { get; set; }
        public virtual DocumentShare DocumentShare { get; set; } = null!;

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}