using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.SalesManagment.Transaction.DTOs
{
    public class ChangeJobOrderDocumentStatusDto
    {
        public long RequestId { get; set; }
        public JobOrderDocumentStatus DocumentStatus { get; set; }
        public string? CancelledDescription { get; set; }
    }
}
