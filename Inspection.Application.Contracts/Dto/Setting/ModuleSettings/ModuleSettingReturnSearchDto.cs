namespace Inspection.Application.Contracts.Dto.Setting.ModuleSettings
{
    public class ModuleSettingReturnSearchDto
    {

        public long Id { get; set; }

        // FK to Program
        public string ProgramId { get; set; }
        //public Program Program { get; set; }
        public string ProgramName { get; set; } = null!;


        // Setting
        public string SettingKey { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public string ValueType { get; set; } = null!;
        public string? Description { get; set; }

        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;



    }
}
