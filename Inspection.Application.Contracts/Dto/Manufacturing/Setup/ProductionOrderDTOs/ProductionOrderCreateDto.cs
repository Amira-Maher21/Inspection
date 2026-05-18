using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs.ProductionOrderLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;

namespace Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs
{
    public class ProductionOrderCreateDto
    {
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public long OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal? ExpectedAmount { get; set; }

        public virtual ICollection<ProductionOrderLineCreateDto> ProductionOrderLines { get; set; } = null!;
    }
}