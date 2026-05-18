using Inspection.Domain.Enums.DMS.DocumentEnums;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs
{
    public class DocumentEntityLinkUpdateDto
    {
        public long Id { get; set; }
        public string ScreenId { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
        public string? EntityName { get; set; }
        public LinkedEntityType LinkedEntityType { get; set; }
    }
}