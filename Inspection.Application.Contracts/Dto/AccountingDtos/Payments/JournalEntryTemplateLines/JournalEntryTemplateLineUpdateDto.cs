namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplateLines
{
    public class JournalEntryTemplateLineUpdateDto
    {
        public long Id { get; set; }
        public long JournalEntryTemplateId { get; set; }
        public long AccountId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public long? CostCenterId { get; set; }
        public long? CostUnitId { get; set; }
        public long? OperaionId { get; set; }
        public long? WBSId { get; set; }
        public long? ItemWorkId { get; set; }
        public string? Description { get; set; }

    }
}
