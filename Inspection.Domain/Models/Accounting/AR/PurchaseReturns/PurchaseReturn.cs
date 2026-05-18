using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnAdjustments;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnLines;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.ApprovalStatus;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.AR.PurchaseReturns
{
    public class PurchaseReturn : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;

        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; } = null!;

        public string ReturnNumber { get; set; } = string.Empty;

        public long? PurchaseInvoiceId { get; private set; }
        public PurchaseInvoice? PurchaseInvoice { get; private set; }

        public long SupplierId { get; private set; }
        public Supplier Supplier { get; private set; } = null!;

        public long ChartOfAccountId { get; private set; }
        public ChartOfAccount? ChartOfAccount { get; private set; }

        public long WarehouseId { get; private set; }
        public Warehouse Warehouse { get; private set; } = null!;

        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;
        public string? Description { get; private set; }

        public DateTime ReturnDate { get; private set; }

        public string? ReturnReason { get; private set; }

        public decimal NetAmount { get; private set; }
        public decimal? TaxAmount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; private set; }
        public decimal? AdditionalDiscountValue { get; private set; }
        public decimal? AdditionalDiscountAmount { get; private set; }
        public decimal? TotalDiscount { get; private set; }

        public PostingEnum Posting { get; private set; }
        public ApprovalStatus ApprovalStatus { get; private set; }

        public List<PurchaseReturnLine> PurchaseReturnLines { get; set; } = new();
        public List<PurchaseReturnAdjustment> PurchaseReturnAdjustments { get; set; } = new();

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}