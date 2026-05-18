using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryLines
{
    public class JournalEntryLineDto
    {
        public long Id { get; set; }
        public long JournalEntryId { get; set; }

        public long ChartOfAccountId { get; set; }

        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }

        public long? CustomerId { get; set; }

        public long? SupplierId { get; set; }

        public long? CostCenterId { get; set; }

        public long? OperationId { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public long? WBSId { get; set; }

        public long? CostCodeId { get; set; }

        public long? ActivityId { get; set; }

        public long? BOQLineId { get; set; }

        public long? SubcontractBOQId { get; set; }

        public long? ProductionOrderId { get; set; }

        public string Description { get; set; } = string.Empty;

        public LineTypeEnum? LineType { get; private set; }
        public long? AssetId { get; private set; }
        public AssetTransactionTypeEnum? AssetTransactionType { get; private set; }
    }
}
