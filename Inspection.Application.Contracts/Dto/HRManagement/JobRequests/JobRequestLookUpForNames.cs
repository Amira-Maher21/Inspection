using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobRequests
{
    public class JobRequestLookUpForNames
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? JobTitleName { get; set; }
        public string? DepartmentName { get; set; }

    }
}
