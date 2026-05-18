using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.ChartOfAccounts
{
    [Table("AccountType")]
    public class AccountType : IRootEntity, ITenantEntity
    {
        public string AccountTypeCode { get; private set; } = string.Empty;
        public string AccountTypeName { get; private set; } = string.Empty;
        public string? ParentAccountType { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;

    }
}