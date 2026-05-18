using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs
{
    public class UpdateApplicantCVDto
    {

        public long? Id { get; set; }

        public long? JobRequestId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? CVUrl { get; set; }
        public string? Qualifications { get; set; }

        public CVStatus? Status { get; set; } = CVStatus.Received;
        public bool? IsInterviewed { get; set; } = false;
    }

}
