using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.Inventory.Ledger;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs
{
    public class LedgerDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = null!;

        public long CompanyId { get; set; }

        // Posting Document
        public long PostingDocumentTypeId { get; set; }

        public long JournalEntryId { get; set; }

        public DateTime PostingDate { get; set; }

        public decimal TotalDebit { get; set; }

        public decimal TotalCredit { get; set; }

        // Currency
        public long CurrencyId { get; set; }

        // Branch
        public long BranchId { get; set; }

        public long PostedById { get; set; }

        public DateTime PostedDate { get; set; }

        public ICollection<LedgerLineDto> LedgerLines { get; set; } = new List<LedgerLineDto>();

        // Auditing
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
