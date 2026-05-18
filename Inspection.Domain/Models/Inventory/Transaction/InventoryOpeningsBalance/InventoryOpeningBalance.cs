using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance
{
    public class InventoryOpeningBalance : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long WarehouseId { get; private set; }
        public Warehouse Warehouse { get; private set; } = null!;
        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; } = null!;
        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;

        // Status
        public PostingEnum Posting { get; private set; }

        public decimal TotalValue { get; private set; }
        public bool YearEndCarryForward { get; private set; } = false;
        public string? Description { get; private set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Details
        public List<InventoryOpeningBalanceLine> InventoryOpeningBalanceLines { get; set; } = null!;

        public void SetAsNormalOpening()
        {
            YearEndCarryForward = false;
        }

    }
}