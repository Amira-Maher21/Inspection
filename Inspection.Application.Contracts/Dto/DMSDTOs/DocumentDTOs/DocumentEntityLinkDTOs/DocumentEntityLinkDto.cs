using Inspection.Domain.Enums.DMS.DocumentEnums;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs
{
    public class DocumentEntityLinkDto
    {
        public long Id { get; set; }
        public long DocumentId { get; set; }
        public string ScreenId { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
        public string? EntityName { get; set; }
        public LinkedEntityType LinkedEntityType { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
