namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs
{
    public class CashTransferLineCreateDto
    {
        public long ChartOfAccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
    }
}