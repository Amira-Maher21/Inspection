using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs.InventoryOpeningBalanceLineDTOs;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs
{
    public class InventoryOpeningBalanceCreateDto
    {
        public long CompanyId { get; set; }
        public long WarehouseId { get; set; }
        public long FiscalYearId { get; set; }
        public long BranchId { get; set; }
        public long CurrencyId { get; set; }

        public PostingEnum Posting { get; set; }
        public decimal TotalValue { get; set; }
        public string? Description { get; set; }
        public List<InventoryOpeningBalanceLineCreateDto> InventoryOpeningBalanceLines { get; set; } = new();
    }
}