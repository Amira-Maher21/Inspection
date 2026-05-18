using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.Inventory.Ledger
{
    public class Ledger : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = null!;

        public long CompanyId { get; set; }

        public string DocumentCode { get; set; } = null!;

        public long PostingDocumentTypeId { get; set; }
        public PostingDocumentType PostingDocumentType { get; set; } = null!;

        public long ReferenceDocumentId { get; set; }

        public DateTime DocumentDate { get; set; }

        public DateTime PostingDate { get; set; }

        public long? JournalEntryId { get; set; }
        public JournalEntry JournalEntry { get; set; } = null!;

        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
        public decimal ExchangeRate { get; set; }

        public long? OfficialCurrencyId { get; set; }
        public Currency OfficialCurrency { get; set; } = null!;
        public decimal ExchangeRateOfficialCurrency { get; set; }

        public long? ReportingCurrencyId { get; set; }
        public Currency ReportingCurrency { get; set; } = null!;
        public decimal ExchangeRateReportingCurrency { get; set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public long PostedById { get; set; }
        public DateTime PostedDate { get; set; }

        public bool IsReferenceDocumentCanceled { get; set; }

        public long? ReverseLedgerId { get; set; }
        public Ledger? ReverseLedger { get; set; }

        public ICollection<LedgerLine> LedgerLines { get; set; } = new List<LedgerLine>();

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
