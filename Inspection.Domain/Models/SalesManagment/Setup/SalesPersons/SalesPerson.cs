using Inspection.Domain.Enums.Sales.Setup;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SalesManagment.Setup.SalesPersons
{
    public class SalesPerson : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Mobile { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;

        public decimal MaxDiscountPercent { get; private set; } = 0;
        public bool CanApproveQuotation { get; private set; } = false;
        public decimal? TargetAmount { get; private set; }

        public DateTime HireDate { get; private set; } = DateTime.Now;
        public long? User_CodeId { get; set; }
        public User_Code User_Code { get; private set; } = null!;


        public SalesPersonEnum SalesRole { get; private set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
