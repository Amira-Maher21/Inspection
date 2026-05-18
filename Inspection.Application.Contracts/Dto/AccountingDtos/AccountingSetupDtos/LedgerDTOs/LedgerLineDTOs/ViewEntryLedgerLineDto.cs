using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Inventory.Ledger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs
{
    public class ViewEntryLedgerDto
    {
        public long Id { get; set; }

        public DateTime PostingDate { get; set; }

        public long ReferenceDocumentId { get; set; }

        public string DocumentCode { get; set; } = null!;

        public List<ViewEntryLedgerLineDto> LedgerLines { get; set; } = new();
    }

    public class ViewEntryLedgerLineDto
    {
        public long Id { get; set; }

        public long LedgerId { get; set; }

        public long? ChartOfAccountId { get; set; }

        public string? AccountCode { get; set; }

        public string? AccountName { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

        public long? CostCenterId { get; set; }

        public long? CostUnitId { get; set; }
    }
}
