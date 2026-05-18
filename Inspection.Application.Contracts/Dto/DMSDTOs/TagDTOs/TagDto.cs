namespace Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs
{
    public class TagDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#808080";

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}