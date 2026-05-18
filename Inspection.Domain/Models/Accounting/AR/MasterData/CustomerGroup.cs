using Inspection.Domain.Models.Accounting.AccountingSystem;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.System.Taxestegories;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.AR.MasterData
{
    [Table("CustomerGroup")]
    public class CustomerGroup : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string GroupCode { get; private set; } = string.Empty;
        public string GroupName { get; private set; } = string.Empty;
        public decimal? CreditLimit { get; private set; }
        public long? PaymentTermsId { get; private set; }

        public virtual PaymentTerm? PaymentTerm { get; private set; }
        public long? DefaultAccountGroupId { get; private set; }
        public virtual DefaultAccountGroup? DefaultAccountGroup { get; private set; }

        public long? TaxCategoryId { get; private set; }
        public virtual TaxCategory? TaxCategory { get; private set; }

        //  tanent
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}

