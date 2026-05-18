using Inspection.Domain.Enums.Sales.Setup;

namespace Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson
{
    public class SalesPersonDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public decimal MaxDiscountPercent { get; set; } = 0;
        public bool CanApproveQuotation { get; set; } = false;
        public decimal? TargetAmount { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;

        public long? User_CodeId { get; set; }

        public SalesPersonEnum SalesRole { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}