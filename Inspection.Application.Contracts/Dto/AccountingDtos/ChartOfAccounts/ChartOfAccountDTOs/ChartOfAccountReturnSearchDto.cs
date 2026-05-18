namespace Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs
{
    public class ChartOfAccountReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;

        public long? ParentAccountId { get; set; }
        //public string ParentAccountCode { get; set; } = string.Empty;
        //public string ParentAccountName { get; set; } = string.Empty;

        public bool IsMain { get; set; }
        public long Level { get; set; }

        //public string AccountTypeId { get; set; } = string.Empty;
        public string AccountTypeCode { get; set; } = string.Empty;
        public string AccountTypeName { get; set; } = string.Empty;

        public long? CurrencyId { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;

        public long? CostUnitId { get; set; }
        public string CostUnitCode { get; set; } = string.Empty;
        public string CostUnitName { get; set; } = string.Empty;

        public long? CostCenterId { get; set; }
        public string CostCenterCode { get; set; } = string.Empty;
        public string CostCenterName { get; set; } = string.Empty;

        public bool IsCostCenterRequired { get; set; }
        public bool IsCostUnitRequired { get; set; }
        public bool IsDisable { get; set; }
        public bool IsControlAccount { get; set; }
        public bool IsReconciliationAccount { get; set; }
        public bool IsCashAccount { get; set; }
        public bool IsBankAccount { get; set; }
    }
}
