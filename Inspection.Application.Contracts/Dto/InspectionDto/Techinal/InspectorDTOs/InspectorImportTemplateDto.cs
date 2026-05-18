namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs
{
    public class InspectorImportTemplateDto
    {
        public long CompanyCode { get; set; }
        public long? EmployeeCode { get; set; }
        public string? User_Code { get; set; }
        public long InspectorCategoryCode { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? HireDate { get; set; }
        public bool Disabled { get; set; } = false;
        public string? QualificationNotes { get; set; }
        public string? Remarks { get; set; }
    }
}