namespace Inspection.Application.Contracts.Dto.HRManagement.Employees
{
    public class EmployeeDto
    {
        public long? Id { get; set; }
        public long? CVId { get; set; }
        public string FullName { get; set; }
        public string ApplicantFullName { get; set; }
        public string EmployeeCode { get; set; }
        public long JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PhotoUrl { get; set; }
        public string NationalId { get; set; }
        public string Qualifications { get; set; }
        public DateTime HireDate { get; set; }
    }

}
