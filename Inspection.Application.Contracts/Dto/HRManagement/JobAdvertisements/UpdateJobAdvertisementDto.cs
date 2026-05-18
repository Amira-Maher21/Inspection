using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements
{
    public class UpdateJobAdvertisementDto
    {
        public long JobRequestId { get; set; }
        public string Platform { get; set; } = default!;
        public string Url { get; set; } = default!;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }

}
