using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs
{
    public class InventoryOpeningBalanceImportTemplateDto
    {
        public long CompanyId { get; set; }
        public long WarehouseCode { get; set; }
        public long FiscalYearCode { get; set; }
        public long BranchCode { get; set; }
        public long CurrencyCode { get; set; }

        public PostingEnum Posting { get; set; }
        public decimal TotalValue { get; set; }
        public string? Description { get; set; }
    }
}