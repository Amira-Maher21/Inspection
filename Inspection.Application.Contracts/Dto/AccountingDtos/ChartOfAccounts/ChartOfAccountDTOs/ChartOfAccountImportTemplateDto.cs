namespace Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs
{
    public class ChartOfAccountImportTemplateDto
    {
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public long? ParentAccountId { get; set; }
        public bool IsMain { get; set; }
        public long Level { get; set; }     // dynamic method 

        public string AccountTypeCode { get; set; } = string.Empty;

        public long? CurrencyId { get; set; }

        public long? CostUnitId { get; set; }

        public long? CostCenterId { get; set; }

        public bool IsCostCenterRequired { get; set; }
        public bool IsCostUnitRequired { get; set; }
        public bool IsDisable { get; set; }
        public bool IsControlAccount { get; set; }
        public bool IsReconciliationAccount { get; set; }
        public bool IsCashAccount { get; set; }
        public bool IsBankAccount { get; set; }
    }
}