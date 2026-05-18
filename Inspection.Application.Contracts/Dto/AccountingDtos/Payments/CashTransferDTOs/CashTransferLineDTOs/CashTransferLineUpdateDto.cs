namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs
{
    public class CashTransferLineUpdateDto
    {
        public long Id { get; set; }

        public long ChartOfAccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
    }
}