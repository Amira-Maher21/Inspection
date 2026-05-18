using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder
{
    public class ChangeSalesOrderDocumentStatusDto
    {
        public long RequestId { get; set; }
        public SalesOrderDocumentStatus DocumentStatus { get; set; }
        public string? CancelledDescription { get; set; }
    }

}
