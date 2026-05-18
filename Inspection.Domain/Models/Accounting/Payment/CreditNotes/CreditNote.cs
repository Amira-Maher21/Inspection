using Inspection.Domain.Enums.Accounting.payments.CreditNotes;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Payment.CreditNotes
{
    public class CreditNote : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Document Number
        public string CreditNoteNumber { get; set; } = string.Empty;

        // Relations
        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;

        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; } = null!;

        public long? SalesInvoiceId { get; private set; }
        public SalesInvoice? SalesInvoice { get; private set; }

        public long CustomerId { get; private set; }
        public Customer Customer { get; private set; } = null!;

        public long ChartOfAccountId { get; private set; }
        public ChartOfAccount Account { get; private set; } = null!;

        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;

        // Description
        public string? Description { get; private set; }

        // Dates
        public DateTime CreditNoteDate { get; private set; }

        // Discount
        public CreditNoteAdditionalDiscountType? AdditionalDiscountType { get; private set; }
        public decimal? AdditionalDiscountValue { get; private set; }
        public decimal? AdditionalDiscountAmount { get; private set; }
        public decimal? TotalDiscount { get; private set; }

        // Tax
        public decimal? TaxAmount { get; private set; }

        // Total
        public decimal TotalAmount { get; private set; }

        // Status
        public PostingEnum Posting { get; private set; }

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
        public List<CreditNoteLine> CreditNoteLines { get; set; } = null!;
        public List<CreditNoteAdjustment> CreditNoteAdjustments { get; set; } = null!;
    }
}