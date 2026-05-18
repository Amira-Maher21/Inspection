using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs
{
    public class CashTransferReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string TransferNumber { get; set; } = string.Empty;

        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public long FiscalYearId { get; set; }
        public string FiscalYearCode { get; set; } = string.Empty;

        public long ChartOfAccountFromId { get; set; }
        public string ChartOfAccountFromCode { get; set; } = string.Empty;
        public string ChartOfAccountFromName { get; set; } = string.Empty;

        public long ChartOfAccountToId { get; set; }
        public string ChartOfAccountToCode { get; set; } = string.Empty;
        public string ChartOfAccountToName { get; set; } = string.Empty;

        public long ModeOfPaymentFromId { get; set; }
        public string ModeOfPaymentFromName { get; set; } = string.Empty;

        public long ModeOfPaymentToId { get; set; }
        public string ModeOfPaymentToName { get; set; } = string.Empty;

        public long CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;

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