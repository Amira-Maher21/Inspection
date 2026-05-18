using Inspection.Domain.Enums;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using Inspection.Domain.Models.HRManagement.JobRequests;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.HRManagement.ApplicantCVs
{
    public class ApplicantCV : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        public long JobRequestId { get; set; }
        public JobRequest JobRequest { get; set; } = default!;

        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string CVUrl { get; set; } = default!;
        public string Qualifications { get; set; } = default!;

        public CVStatus Status { get; set; } = CVStatus.Received;
        public bool IsInterviewed { get; set; } = false;

        public InterviewEvaluation? InterviewEvaluation { get; set; }
        public JobOfferNegotiation? Negotiation { get; set; }

        public bool? AcceptedOffer { get; set; }
        public bool? WillJoin { get; set; }

        public string? Tenant_ID { get; set; }
    }

}
