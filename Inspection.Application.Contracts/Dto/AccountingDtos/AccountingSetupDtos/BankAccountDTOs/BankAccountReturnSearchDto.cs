namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs
{
    public class BankAccountReturnSearchDto
    {

        public long Id { get; set; }
        public string BankAccountNumber { get; set; }
        public string IBAN { get; set; }
        public string AccountType { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public bool IsCompanyAccount { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


        //  
        public long BankId { get; set; }
        public string BankCode { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;

        public long CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;

        public long ChartOfAccountId { get; set; }
        public string ChartOfAccountCode { get; set; } = string.Empty;
        public string ChartOfAccountName { get; set; } = string.Empty;
    }
}
