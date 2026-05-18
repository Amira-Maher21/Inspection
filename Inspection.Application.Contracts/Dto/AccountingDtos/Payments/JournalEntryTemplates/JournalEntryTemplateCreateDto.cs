using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplateLines;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates
{
    public class JournalEntryTemplateCreateDto
    {

        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? BranchId { get; set; }
        public long CurrencyId { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string? BillNo { get; set; }
        public DateTime? BillDate { get; set; }

        public DateTime? DueDate { get; set; }

        public long? ModeOfPaymentId { get; set; }
        public string? Description { get; set; }

        public List<JournalEntryTemplateLineCreateDto> JournalEntryTemplateLines { get; set; } = new List<JournalEntryTemplateLineCreateDto>();

    }
}
