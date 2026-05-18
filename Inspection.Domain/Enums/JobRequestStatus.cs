using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums
{
    public enum JobRequestStatus
    {
        Pending = 0,
        HRProcessing = 1,
        JobPostedExternally = 2,
        CVsReceived = 3,
        CandidatesShortlisted = 4,
        InterviewsScheduled = 5,
        InterviewsCompleted = 6,
        UnderNegotiation = 7,
        FinalCandidateSelected = 8,
        OfferAccepted = 9,
        Hired = 10
    }

}
