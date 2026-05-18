namespace Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs
{
    public class TagCreateDto
    {
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#808080";
    }
}