namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs
{
    public class InspectionMethodReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}