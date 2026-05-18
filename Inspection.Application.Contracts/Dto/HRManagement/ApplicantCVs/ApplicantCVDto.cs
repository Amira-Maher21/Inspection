using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs
{
    public class ApplicantCVDto
    {
        public long Id { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public string? Address { get; set; }
        //public CVStatus Status { get; set; }
        //public long JobTitleId { get; set; }
        //public string? JobTitleName { get; set; }   
        public long JobRequestId { get; set; }
        public string? JobRequestTitle { get; set; }

        public CVStatus Status { get; set; }
        public bool IsInterviewed { get; set; }
        public string CVUrl { get; set; } = default!;
        public string Qualifications { get; set; } = default!;
    }

}
