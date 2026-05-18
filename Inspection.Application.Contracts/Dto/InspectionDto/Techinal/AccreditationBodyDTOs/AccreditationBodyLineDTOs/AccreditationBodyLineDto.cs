namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs.AccreditationBodyLineDTOs
{
    public class AccreditationBodyLineDto
    {
        public long Id { get; set; }

        public long AccreditationBodyId { get; set; }

        public long InspectionTypeId { get; set; }
        public long InspectionStandardId { get; set; }

        public string? RiskLevel { get; set; }
        public string? Description { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}