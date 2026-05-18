using Inspection.Domain.Enums.AccountResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inspection.Domain.Models.AccountResolution
{
    public class AccountResolverContext
    {
        // Document Info
        //public string AccountSource { get; set; } = string.Empty;

        public long? CustomerId { get; init; }
        public long? ItemId { get; init; }

        public AccountResolverPurpose Purpose { get; init; }

    }
}
