using Inspection.Domain.Models.HRManagement.Departments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.AR.MasterData
{


    public class CustomerContact : IAuditable, IRootEntity
    {
        public long Id { get; private set; } // PK

        public long CustomerId { get; set; } // FK Customers
        public Customer Customer { get; set; } = null!;

        public string ContactName { get; private set; } = null!;
        public string? JobTitle { get; private set; }
        public string? Phone { get; private set; }
        public string? Mobile { get; private set; }
        public string? Email { get; private set; }
        public string? Fax { get; private set; }

        public long? DepartmentId { get; private set; }
        public Department? Department { get; private set; }

        public bool IsPrimary { get; private set; }
        public string? Notes { get; private set; }

        // Auditing
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Constructor for EF Core
        private CustomerContact() { }

    }
}
