using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.Posting
{
    public class PostDocumentRequest
    {
        public string DocumentCode { get; set; }
        public long Id { get; set; }
    }
}
