namespace Inspection.Application.Contracts.Dto.Setting.ModuleSettings
{
    public class ModuleSettingUpdateDto
    {
        public long Id { get; set; }

        // FK to Program
        public string ProgramId { get; set; }

        // Setting
        public string SettingKey { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public string ValueType { get; set; } = null!;
        public string? Description { get; set; }

        public long CompanyId { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;


    }
}
