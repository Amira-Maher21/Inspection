using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.System.Taxes;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.ApprovalStatus;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Payment.CashReceipts
{
    public class CashReceipt : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Document Numbers
        public string ReceiptNumber { get; set; } = string.Empty;
        public string? ManualNumber { get; private set; }

        // Relations
        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; } = null!;
        public long AccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; } = null!;
        public long CustomerId { get; private set; }
        public Customer Customer { get; private set; } = null!;
        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;

        // Description
        public string? Description { get; private set; }
        public string? ReceivedFrom { get; private set; }

        // Dates
        public DateTime ReceiptDate { get; private set; }
        public DateTime PostingDate { get; private set; }

        // Tax
        public long? TaxTypeId { get; private set; }
        public TaxType? TaxType { get; private set; }
        public decimal? TaxPercent { get; private set; }
        public decimal? TaxAmount { get; private set; }

        // Amount
        public decimal TotalAmount { get; private set; }

        // Status
        public PostingEnum Posting { get; private set; }
        public ApprovalStatus ApprovalStatus { get; private set; }

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Details
        public List<CashReceiptLine> CashReceiptLines { get; set; } = null!;
        public List<CashReceiptAdjustment> CashReceiptAdjustments { get; set; } = null!;
        public List<SalesInvoiceAllocation> SalesInvoiceAllocations { get; set; } = null!;
    }
}