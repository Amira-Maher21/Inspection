using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.Posting
{
    public class PostingResult
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public List<ProcessedDocumentInfo> ProcessedDocuments { get; set; }
    }
}
