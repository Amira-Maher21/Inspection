using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations
{
    public class CreateJobOfferNegotiationDto
    {
        public long ApplicantCVId { get; set; }

        public string ProposedSalary { get; set; } = default!;
        public DateTime ProposedStartDate { get; set; }
        public string Notes { get; set; } = default!;
    }

}
    