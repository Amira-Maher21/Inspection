using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums
{
    public enum CandidateStatus
    {
        New = 0,
        Shortlisted = 1,
        InterviewScheduled = 2,
        Interviewed = 3,
        RejectedAfterInterview = 4,
        UnderNegotiation = 5,
        OfferAccepted = 6,
        OfferRejected = 7,
        Hired = 8
    }

}
