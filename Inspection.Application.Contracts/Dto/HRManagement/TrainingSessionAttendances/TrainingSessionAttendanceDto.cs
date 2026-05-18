using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.TrainingSessionAttendances
{
    public class TrainingSessionAttendanceDto  
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; } = default!;  
        public long TrainingProgramId { get; set; }
        public string TrainingProgramTitle { get; set; } = default!;  
        public bool Attended { get; set; }
        public bool SignedByEmployee { get; set; }
        public bool SignedBySupervisor { get; set; }
        public TrainingEvaluationResult Result { get; set; }
        public string Notes { get; set; } = default!;
    }

}
