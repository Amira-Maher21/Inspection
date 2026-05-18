using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Event;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryLines;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.ApprovalStatus;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys
{
    public class JournalEntry : IRootEntity, ITenantEntity, IAuditable, ISeries, IPostingEntity
    {
        [Key]
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string JournalNo { get; set; }


        public long FiscalYearId { get; set; }
        public FiscalYear FiscalYear { get; set; }

        public DateTime JournalDate { get; set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; }

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; }


        public long? JournalEntryTemplateId { get; set; }
        public JournalEntryTemplate? JournalEntryTemplate { get; set; }


        public bool? IsReverseJournal { get; set; }
        public long? ReversalOfJournalEntryId { get; set; }
        public JournalEntry? ReversalOfJournalEntry { get; set; }

        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }

        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }

        public DocumentStatus? DocumentStatus { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public string Description { get; set; }

        public virtual ICollection<JournalEntryLine> JournalEntryLines { get; set; } = new List<JournalEntryLine>();

        public Series? Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Posting
        public DateTime PostingDate { get; set; }
        public string DocumentCode { get; set; } = "JournalEntry";
        public PostingEnum Posting { get; set; } = PostingEnum.Draft;
        public decimal ExchangeRate { get; set; } = 1;
    }
}
