using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.ApprovalStatus;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns
{
    public class SalesReturn : IRootEntity, ITenantEntity, IAuditable
    {

        public long Id { get; set; }

        public string Tenant_ID { get; set; }
        public long CompanyId { get; private set; }
        public long BranchId { get; private set; }
        public Branch Branch { get; private set; }
        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; }

        public string ReturnNumber { get; set; }

        public long? SalesInvoiceId { get; private set; }
        public SalesInvoice? SalesInvoice { get; private set; }
        public long CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public long ChartOfAccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; }

        public long WarehouseId { get; private set; }
        public Warehouse Warehouse { get; private set; }
        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; }

        public string Description { get; private set; }

        public DateTime ReturnDate { get; private set; }

        public string ReturnReason { get; private set; }

        public decimal NetAmount { get; private set; }
        public decimal? TaxAmount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; private set; }

        public int? AdditionalDiscountType { get; private set; }
        public decimal? AdditionalDiscountValue { get; private set; }
        public decimal? AdditionalDiscountAmount { get; private set; }
        public decimal? TotalDiscount { get; private set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Navigation
        public List<SalesReturnLine> SalesReturnLines { get; set; } = new();
        public List<SalesReturnAdjustment> SalesReturnAdjustments { get; set; } = new();


    }
}