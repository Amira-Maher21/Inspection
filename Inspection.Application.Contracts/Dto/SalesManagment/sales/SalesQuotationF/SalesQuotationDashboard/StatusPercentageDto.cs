using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class StatusPercentageDto
    {
        public SalesQuotationStatus Status { get; set; }
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

}
