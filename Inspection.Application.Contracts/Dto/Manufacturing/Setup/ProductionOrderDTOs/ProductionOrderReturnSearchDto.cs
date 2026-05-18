using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs.ProductionOrderLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;

namespace Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs
{
    public class ProductionOrderReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long OperationId { get; set; }
        public string OperationCode { get; set; } = string.Empty;
        public string OperationName { get; set; } = string.Empty;
        public long OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal? ExpectedAmount { get; set; }

        public virtual ICollection<ProductionOrderLineDto> ProductionOrderLines { get; set; } = null!;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}