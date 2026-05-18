namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs
{
    public class InspectorUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long? EmployeeId { get; set; }
        public long? User_CodeId { get; set; }
        public long InspectorCategoryId { get; set; }

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