namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards
{
    public class InspectionStandardApplicabilityRuleUpdateDto
    {
        public long Id { get; set; }
        public long StandardId { get; set; }
        public long EquipmentTypeId { get; set; }
        public long? InspectionTypeId { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string? Unit { get; set; }
        public bool IsMandatory { get; set; }
        public bool Disable { get; set; }
        public long CompanyId { get; set; }
    }
}
