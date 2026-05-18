using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobRequests
{
    public class CreateJobRequestDto
    {
        public long DepartmentId { get; set; }
        public long JobTitleId { get; set; }
        public string JobDescription { get; set; } = default!;
        public int NeededPositions { get; set; }
    }

}
