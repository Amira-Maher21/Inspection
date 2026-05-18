using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation
{
    public class ApprovalDelegationApprovalDLookUpDto
    {
        public long IDScrAproval { get; set; }
        public string Approval_title { get; set; } = null!;
    }
}
