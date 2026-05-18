namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs.AccreditationBodyLineDTOs
{
    public class AccreditationBodyLineUpdateDto
    {
        public long Id { get; set; }

        public long InspectionTypeId { get; set; }
        public long InspectionStandardId { get; set; }
        public string? RiskLevel { get; set; }
        public string? Description { get; set; }
    }
}