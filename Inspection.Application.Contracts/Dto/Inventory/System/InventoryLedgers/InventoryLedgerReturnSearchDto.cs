using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers
{
    public class InventoryLedgerReturnSearchDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public long WarehouseId { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;

        public long? WarehouseLocationId { get; set; }
        public string? LocationCode { get; set; }
        public string? LocationName { get; set; }

        public long ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;

        public string CurrencyCode { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;

        public long UnitOfMeasureId { get; set; }
        public string UoMCode { get; set; } = string.Empty;
        public string UoMName { get; set; } = string.Empty;

        public DateTime TransactionDate { get; set; }
        public DateTime PostingDate { get; set; }

        public decimal? QuantityIn { get; set; }
        public decimal? QuantityOut { get; set; }
        public decimal BalanceAfter { get; set; }
        public decimal? UnitCost { get; set; }

        public string TransactionType { get; set; } = string.Empty;
        public string? SourceType { get; set; }
        public long? ReferenceDocumentId { get; set; }


        public CostingMethodEnum CostingMethod { get; set; }

        public long PostingDocumentTypeId { get; set; }

        public string? Description { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}