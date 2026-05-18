using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs.AccreditationBodyLineDTOs;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs
{
    public class AccreditationBodyReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? WebsiteUrl { get; set; }
        public bool IsInternationallyRecognized { get; set; }

        public long CountryId { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;

        public List<AccreditationBodyLineDto> AccreditationBodyLines { get; set; } = new();

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}