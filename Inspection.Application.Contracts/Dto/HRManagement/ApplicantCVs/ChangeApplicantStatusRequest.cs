using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs
{
    public class ChangeApplicantStatusRequest
    {
        public CVStatus Status { get; set; }
    }
}
