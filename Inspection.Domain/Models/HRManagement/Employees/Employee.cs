using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.JobTitles;
using Inspection.Domain.Models.HRManagement.TrainingSessionAttendances;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.HRManagement.Employees
{
    public class Employee : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public long? CVId { get; set; }
        public ApplicantCV CV { get; set; } = default!;

        public string FullName { get; set; } = default!;
        public string EmployeeCode { get; set; } = default!;
        public long JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; } = default!;
        public long DepartmentId { get; set; }
        public Department Department { get; set; }

        public string PhotoUrl { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public string Qualifications { get; set; } = default!;
        public DateTime HireDate { get; set; } = DateTime.UtcNow;

        public ICollection<TrainingSessionAttendance> Trainings { get; set; } = new List<TrainingSessionAttendance>();
        public string? Tenant_ID { get; set; }
    }

}
