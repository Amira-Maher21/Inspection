using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements
{
    public class JobAdvertisementDto
    {
        [Key]
        public long Id { get; set; }
        public long JobRequestId { get; set; }
        public string Platform { get; set; } = default!;
        public string Url { get; set; } = default!;
        public DateTime PostedAt { get; set; }
        public RequestStatus? JobRequestStatus { get; set; }
        public string JobTitle { get; set; }

    }

}
