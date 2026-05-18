namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards
{
    public class InspectionStandardApplicabilityRuleDto
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
        public string Tenant_ID { get; set; } = string.Empty;



        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
