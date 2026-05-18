using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs.AccreditationBodyLineDTOs;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs
{
    public class AccreditationBodyCreateDto
    {
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? WebsiteUrl { get; set; }
        public bool IsInternationallyRecognized { get; set; }
        public long CountryId { get; set; }
        public List<AccreditationBodyLineCreateDto> AccreditationBodyLines { get; set; } = new();
    }
}