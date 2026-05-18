namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    namespace Inspection.Application.Contracts.Dto.SalesManagement.Dashboard
    {
        public class QuotationByStatusDto
        {
            public string Status { get; set; }
            public int Count { get; set; }
            public double Percentage { get; set; }
            public double AvgDays { get; set; }

        }
    }

}
