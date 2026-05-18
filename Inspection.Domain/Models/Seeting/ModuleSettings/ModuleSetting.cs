using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Seeting.ModuleSettings
{
    public class ModuleSetting : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        // FK to Program
        public string ProgramId { get; set; }
        public Program Program { get; set; }

        // Setting
        public string SettingKey { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public string ValueType { get; set; } = null!;
        public string? Description { get; set; }

        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
