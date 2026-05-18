namespace Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs
{
    public class TagUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#808080";
    }
}