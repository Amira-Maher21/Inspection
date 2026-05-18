using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations
{
    public class JobOfferNegotiationDto
    {
        [Key]
        public long Id { get; set; } = default!;
        public string ProposedSalary { get; set; } = default!;
        public DateTime ProposedStartDate { get; set; }
        public string Notes { get; set; } = default!;
        public string? ApplicantFullName { get; set; }
        public long ApplicantCVId { get; set; }

    }

}
