using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.System.Taxestegories;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.System.Taxes
{

    public class TaxType : IRootEntity, ITenantEntity, IAuditable
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [Precision(18, 2)]
        public decimal Percentage { get; set; }
        public string Description { get; set; }


        public bool IsActive { get; set; }
        public bool IsRecoverable { get; set; }
        public bool IsInclusive { get; set; }


        public long taxCategoryId { get; set; }
        public TaxCategory taxCategory { get; set; }

        public long TaxAccountId { get; set; }
        public ChartOfAccount TaxAccount { get; set; }

        public bool IsExempt { get; set; }
        public string? EtaCodeEgypt { get; set; }
        public bool IsSystem { get; set; }
        public List<TaxTypeLine> TaxTypeLine { get; set; } = new List<TaxTypeLine>();


        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }





    }
}
