using Inspection.Domain.Enums;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobTitles;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.HRManagement.JobRequests
{

    public class JobRequest : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }

        public long JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }

        public string JobDescription { get; set; } = default!;
        public int NeededPositions { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public ICollection<JobAdvertisement> Advertisements { get; set; } = new List<JobAdvertisement>();
        public ICollection<ApplicantCV> CVs { get; set; } = new List<ApplicantCV>();
        public string? Tenant_ID { get; set; }
    }

}
