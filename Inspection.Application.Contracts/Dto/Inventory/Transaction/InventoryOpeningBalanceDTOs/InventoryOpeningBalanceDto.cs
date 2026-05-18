using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs.InventoryOpeningBalanceLineDTOs;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs
{
    public class InventoryOpeningBalanceDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long WarehouseId { get; set; }
        public long FiscalYearId { get; set; }
        public long BranchId { get; set; }
        public long CurrencyId { get; set; }

        public PostingEnum Posting { get; set; }
        public decimal TotalValue { get; set; }
        public bool YearEndCarryForward { get; set; } = false;
        public string? Description { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<InventoryOpeningBalanceLineDto> InventoryOpeningBalanceLines { get; set; } = new();

    }
}