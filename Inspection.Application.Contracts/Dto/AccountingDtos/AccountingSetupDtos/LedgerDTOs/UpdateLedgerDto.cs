using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs
{
    public class UpdateLedgerDto
    {
        public long Id { get; set; }

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

        public ICollection<UpdateLedgerLineDto> LedgerLines { get; set; } = new List<UpdateLedgerLineDto>();

        // Auditing
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
