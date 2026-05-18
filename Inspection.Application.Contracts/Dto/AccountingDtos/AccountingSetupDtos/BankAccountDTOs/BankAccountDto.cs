namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs
{
    public class BankAccountDto
    {
        public long Id { get; set; }
        public long BankId { get; set; }
        public string BankAccountNumber { get; set; }
        public string IBAN { get; set; }
        public string AccountType { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public long CurrencyId { get; set; }
        public bool IsCompanyAccount { get; set; }
        public long ChartOfAccountId { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }





    }
}
