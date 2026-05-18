using Inspection.Domain.Enums.Sales.Setup;

namespace Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson
{
    public class SalesPersonCreateDto
    {

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

    }
}
