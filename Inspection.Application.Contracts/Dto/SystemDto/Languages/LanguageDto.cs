namespace Inspection.Application.Contracts.Dto.SystemDto.Languages
{
    public class LanguageDto
    {
        public string LocaleCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string ISOCode { get; set; } = string.Empty;

        public byte Direction { get; set; }

        public bool Active { get; set; }



        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
