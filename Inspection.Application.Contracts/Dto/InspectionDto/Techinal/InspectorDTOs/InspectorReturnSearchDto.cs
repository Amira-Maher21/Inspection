namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs
{
    public class InspectorReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long? EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }

        public long? User_CodeId { get; set; }
        public string? UserName { get; set; }
        //public string? User_Id { get; set; }

        public long InspectorCategoryId { get; set; }
        public string InspectorCategoryCode { get; set; } = string.Empty;
        public string InspectorCategoryName { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? HireDate { get; set; }
        public bool Disabled { get; set; } = false;
        public string? QualificationNotes { get; set; }
        public string? Remarks { get; set; }
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }



        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
    }
}