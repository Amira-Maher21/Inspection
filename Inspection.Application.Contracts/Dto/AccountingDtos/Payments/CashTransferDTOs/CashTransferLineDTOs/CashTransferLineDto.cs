namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs.CashTransferLineDTOs
{
    public class CashTransferLineDto
    {
        public long Id { get; set; }

        public long CashTransferId { get; set; }
        public long ChartOfAccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}