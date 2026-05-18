using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations
{
    public class CreateInterviewEvaluationDto
    {
        public long ApplicantCVId { get; set; }
        public string TechnicalEvaluation { get; set; } = default!;
        public string BehavioralEvaluation { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string InterviewerName { get; set; } = default!;
        public DateTime InterviewDate { get; set; }
        public InterviewResult Result { get; set; }

    }

}
