using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs
{
    public class CashTransferCreateDto
    {
        public long CompanyId { get; set; }
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

        public List<CashTransferLineCreateDto> CashTransferLines { get; set; } = null!;
    }
}