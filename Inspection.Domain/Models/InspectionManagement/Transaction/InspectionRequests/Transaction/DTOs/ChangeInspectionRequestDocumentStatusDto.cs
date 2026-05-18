using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.InspectionManagement.Transaction.InspectionRequests.DTOs
{
    public class ChangeInspectionRequestDocumentStatusDto
    {
        public InspectionDocumentStatus DocumentStatus { get; set; }
        public string? CancelledDescription { get; set; }
    }
}
