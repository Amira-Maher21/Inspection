namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs
{
    public class DocumentEntityLinkCreateWithOutDocumentIdDto
    {
        public long DocumentId { get; set; }

        public string ScreenId { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
        public string? EntityName { get; set; }

        //public LinkedEntityType LinkedEntityType { get; set; } = LinkedEntityType.Related;
    }
}
