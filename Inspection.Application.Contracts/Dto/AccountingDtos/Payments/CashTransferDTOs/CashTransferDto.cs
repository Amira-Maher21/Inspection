using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs
{
    public class CashTransferDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string TransferNumber { get; set; } = string.Empty;
        public long BranchId { get; set; }
        public long FiscalYearId { get; set; }
        public long ChartOfAccountFromId { get; set; }
        public long ChartOfAccountToId { get; set; }
        public long ModeOfPaymentFromId { get; set; }
        public long ModeOfPaymentToId { get; set; }
        public long CurrencyId { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsInTransit { get; set; }
        public PostingEnum Posting { get; set; }
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<CashTransferLineDto> CashTransferLines { get; set; } = null!;
    }
}