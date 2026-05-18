using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class SalesQuotationDashboardFilterDto
    {
        public long? CustomerId { get; set; }
        public long? SalesPersonId { get; set; }
        //public SalesQuotationStatus? ApprovalStatus { get; set; }
        public SalesQuotationDocumentStatus? DocumentStatus { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }



        public int? AgingDays { get; set; }

        public long? ItemId { get; set; }


    }

}
