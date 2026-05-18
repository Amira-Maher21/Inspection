namespace Inspection.Application.Contracts.Dto.HRManagement.Employees
{
    public class UpdateEmployeeDto
    {
        public long? Id { get; set; }
        public long? CVId { get; set; }
        public string FullName { get; set; }
        public string EmployeeCode { get; set; }
        public long JobTitleId { get; set; }
        public long DepartmentId { get; set; }
        public string PhotoUrl { get; set; }
        public string NationalId { get; set; }
        public string Qualifications { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
    }

}
