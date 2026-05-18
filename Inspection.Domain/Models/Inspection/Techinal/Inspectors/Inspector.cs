using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.InspectionManagement.InspectorCategories;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.Inspectors
{

    public class Inspector : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public long? EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;
        public long? User_CodeId { get; private set; }
        public User_Code User { get; private set; } = null!;
        public long InspectorCategoryId { get; private set; }
        public InspectorCategory InspectorCategory { get; private set; } = null!;
        public string Code { get; set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public DateTime? HireDate { get; private set; }
        public bool Disabled { get; private set; } = false;
        public string? QualificationNotes { get; private set; }
        public string? Remarks { get; private set; }
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


        // series related
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
    }
}