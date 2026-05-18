using Inspection.Domain.Enums.DMS.ShareAccessLog;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs
{
    public class ShareAccessLogReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public DateTime AccessedAt { get; set; }

        public string? AccessIp { get; set; }

        public string? UserAgent { get; set; }


        public ShareAccessLogAction? Action { get; set; }

        public long DocumentShareId { get; set; }
        public long ShareToken { get; set; }


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
