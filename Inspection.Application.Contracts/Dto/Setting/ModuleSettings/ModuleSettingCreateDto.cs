namespace Inspection.Application.Contracts.Dto.Setting.ModuleSettings
{
    public class ModuleSettingCreateDto
    {

        // FK to Program
        public string ProgramId { get; set; }

        // Setting
        public string SettingKey { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public string ValueType { get; set; } = null!;
        public string? Description { get; set; }

        public long CompanyId { get; set; }

    }
}
