using Inspection.Domain.Enums;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.TrainingPrograms;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.HRManagement.TrainingSessionAttendances
{
    public class TrainingSessionAttendance : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;
        public long TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; } = default!;
        public bool Attended { get; set; }
        public bool SignedByEmployee { get; set; }
        public bool SignedBySupervisor { get; set; }
        public TrainingEvaluationResult Result { get; set; }
        public string Notes { get; set; } = default!;
        public string? Tenant_ID { get; set; }
    }

}
