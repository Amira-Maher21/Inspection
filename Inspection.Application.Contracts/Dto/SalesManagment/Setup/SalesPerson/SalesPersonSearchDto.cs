using Inspection.Domain.Enums.Sales.Setup;

namespace Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson
{
    public class SalesPersonSearchDto
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
        public string User_Name { get; set; } = null!;

        public SalesPersonEnum SalesRole { get; set; }
    }
}