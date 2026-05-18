namespace Inspection.Application.Contracts.Dto.SystemDto.Languages
{
    public class LanguageUpdateDto
    {
        public string LocaleCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string ISOCode { get; set; } = string.Empty;

        public byte Direction { get; set; }

        public bool Active { get; set; }






    }
}
