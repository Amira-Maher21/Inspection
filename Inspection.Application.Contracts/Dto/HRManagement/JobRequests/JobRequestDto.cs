using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobRequests
{
    public class JobRequestDto 
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; } = default!;

        public long JobTitleId { get; set; }
        public string JobTitleName { get; set; } = default!;

        public string JobDescription { get; set; } = default!;
        public int NeededPositions { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
    }

}
