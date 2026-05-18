using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates
{
    public class JournalEntryTemplate
        : IRootEntity, ITenantEntity, IAuditable, ISeries
    {

        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public string? Description { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public Series? Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string JournalEntryTemplateNumber { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<JournalEntryTemplateLine> JournalEntryTemplateLines { get; set; } = new List<JournalEntryTemplateLine>();

    }
}
