using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryLines;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys
{
    public class JournalEntryDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string JournalNo { get; set; }


        public long FiscalYearId { get; set; }

        public DateTime JournalDate { get; set; }
        public DateTime PostingDate { get; set; }

        public long BranchId { get; set; }

        public long CurrencyId { get; set; }


        public long? JournalEntryTemplateId { get; set; }


        public bool? IsReverseJournal { get; set; }
        public long? ReversalOfJournalEntryId { get; set; }

        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }

        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }

        public DocumentStatus? DocumentStatus { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public string Description { get; set; }

        public virtual ICollection<JournalEntryLineDto> JournalEntryLines { get; set; } = new List<JournalEntryLineDto>();

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
