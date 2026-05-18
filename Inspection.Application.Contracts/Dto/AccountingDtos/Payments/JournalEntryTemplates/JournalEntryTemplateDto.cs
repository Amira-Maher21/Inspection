using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplateLines;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates
{
    public class JournalEntryTemplateDto
    {
        public long Id { get; set; }
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
        public string Tenant_ID { get; set; } = string.Empty;
        public Series? Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<JournalEntryTemplateLineDto> JournalEntryTemplateLines { get; set; } = new List<JournalEntryTemplateLineDto>();

    }
}
