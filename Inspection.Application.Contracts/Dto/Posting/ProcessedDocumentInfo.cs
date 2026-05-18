using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.Posting
{
    public class ProcessedDocumentInfo
    {
        public string DocumentCode { get; set; }
        public long DocumentId { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ProcessedAt { get; set; }
    }
}
