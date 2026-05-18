using Inspection.Application.Contracts.Dto.Manufacturing.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;

namespace Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs
{
    public class ProductionOrderUpdateDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public long OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal? ExpectedAmount { get; set; }

        public virtual ICollection<ProductionOrderLineUpdateDto> ProductionOrderLines { get; set; } = null!;
    }
}