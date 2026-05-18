using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.TrainingPrograms
{
    public class CreateTrainingProgramDto
    {
        public string Title { get; set; } = default!;
        public TrainingType Type { get; set; }
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Supervisor { get; set; } = default!;
    }

}
