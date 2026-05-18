using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.HRManagement.JobOfferNegotiations
{
    public class JobOfferNegotiation : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public string ProposedSalary { get; set; } = default!;
        public DateTime ProposedStartDate { get; set; }
        public string Notes { get; set; } = default!;
        public long ApplicantCVId { get; set; }
        public ApplicantCV ApplicantCV { get; set; } = default!;
        public string? Tenant_ID { get; set; }


    }

}
