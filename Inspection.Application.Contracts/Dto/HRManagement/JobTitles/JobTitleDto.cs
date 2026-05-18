using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobTitles
{
    public class JobTitleDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; } = default!;
    }

}
