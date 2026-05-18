using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.Payment.CashTransfers
{
    public class CashTransferLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent
        public long CashTransferId { get; set; }
        public CashTransfer CashTransfer { get; set; } = null!;

        // Accounting
        public long ChartOfAccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; } = null!;

        public decimal Amount { get; private set; }

        // Notes
        public string? Notes { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}