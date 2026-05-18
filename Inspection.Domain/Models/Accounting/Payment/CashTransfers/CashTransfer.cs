using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Payment.CashTransfers
{
    public class CashTransfer : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Document Number
        public string TransferNumber { get; set; } = string.Empty;

        // Relations

        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;

        public long FiscalYearId { get; private set; }
        public FiscalYear FiscalYear { get; private set; } = null!;

        // From Account
        public long ChartOfAccountFromId { get; private set; }
        public ChartOfAccount ChartOfAccountFrom { get; private set; } = null!;

        // To Account
        public long ChartOfAccountToId { get; private set; }
        public ChartOfAccount ChartOfAccountTo { get; private set; } = null!;

        // Payment Modes (Cash / Bank)
        // From Mode of Payment 
        public long ModeOfPaymentFromId { get; private set; }
        public ModeOfPayment ModeOfPaymentFrom { get; private set; } = null!;

        // To Mode of Payment
        public long ModeOfPaymentToId { get; private set; }
        public ModeOfPayment ModeOfPaymentTo { get; private set; } = null!;

        // Currency
        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;

        // Details
        public DateTime TransferDate { get; private set; }
        public decimal Amount { get; private set; }
        public bool IsInTransit { get; private set; }

        // Status
        public PostingEnum Posting { get; private set; }

        // Optional Info
        public string? Notes { get; private set; }
        public string? ReferenceNumber { get; private set; }
        public DateTime? ReferenceDate { get; private set; }

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        //Details
        public List<CashTransferLine> CashTransferLines { get; set; } = null!;

    }
}