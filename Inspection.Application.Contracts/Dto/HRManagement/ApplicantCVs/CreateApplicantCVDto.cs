using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs
{
    public class CreateApplicantCVDto
    {
        //public string FullName { get; set; } = string.Empty;
        //public string PhoneNumber { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public string? Address { get; set; }
        //public CVStatus Status { get; set; } = CVStatus.Received;
        //public long JobTitleId { get; set; } 
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CVUrl { get; set; }
        public string Qualifications { get; set; }

        public CVStatus Status { get; set; } = CVStatus.Received;
        public bool IsInterviewed { get; set; } = false;

        public long JobRequestId { get; set; }
    }

}
