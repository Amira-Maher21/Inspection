using Inspection.Domain.Enums;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.AccountingSystem
{
    [Table("DefaultAccountGroup")]

    public class DefaultAccountGroup : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        public string GroupCode { get; private set; } = string.Empty;

        public string GroupName { get; private set; } = string.Empty;
        public EntityType EntityType { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
