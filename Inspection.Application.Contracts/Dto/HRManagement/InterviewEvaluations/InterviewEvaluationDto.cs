using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations
{
    public class InterviewEvaluationDto
    {
        [Key]
        public long Id { get; set; }
        public string TechnicalEvaluation { get; set; } = default!;
        public string BehavioralEvaluation { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string InterviewerName { get; set; } = default!;
        public DateTime InterviewDate { get; set; }
        public InterviewResult Result { get; set; }
        public long ApplicantCVId { get; set; }

    }

}
