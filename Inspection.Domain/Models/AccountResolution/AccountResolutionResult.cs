using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.AccountResolution
{
    public class AccountResolutionResult
    {
        public long AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string ResolvedBy { get; set; } 
        public int Priority { get; set; }

        public static AccountResolutionResult Resolved(
            long accountId, string code, string name, string resolvedBy, int priority)
            => new()
            {
                AccountId = accountId,
                AccountCode = code,
                AccountName = name,
                ResolvedBy = resolvedBy,
                Priority = priority
            };
    }

}
