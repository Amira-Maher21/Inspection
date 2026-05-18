using Inspection.Domain.Enums;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.HRManagement.InterviewEvaluations
{

    public class InterviewEvaluation : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public long ApplicantCVId { get; set; }
        public ApplicantCV ApplicantCV { get; set; } = default!;
        public string TechnicalEvaluation { get; set; } = default!;
        public string BehavioralEvaluation { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string InterviewerName { get; set; } = default!;
        public DateTime InterviewDate { get; set; }
        public InterviewResult Result { get; set; }
        public string? Tenant_ID { get; set; }
    }
}
