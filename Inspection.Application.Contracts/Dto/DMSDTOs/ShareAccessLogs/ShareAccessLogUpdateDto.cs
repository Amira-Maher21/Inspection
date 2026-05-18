using Inspection.Domain.Enums.DMS.ShareAccessLog;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs
{
    public class ShareAccessLogUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }

        public DateTime AccessedAt { get; set; }

        public string? AccessIp { get; set; }

        public string? UserAgent { get; set; }


        public ShareAccessLogAction? Action { get; set; }

        public long DocumentShareId { get; set; }

    }
}
