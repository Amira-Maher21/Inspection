using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.InspectionManagement.InspectionRequests.Transaction.DTOs
{
    public class ChangeInspectionRequestDocumentStatusDto
    {
        public long RequestId { get; set; }
        public InspectionDocumentStatus DocumentStatus { get; set; }
        public string? CancelledDescription { get; set; }
    }
}
