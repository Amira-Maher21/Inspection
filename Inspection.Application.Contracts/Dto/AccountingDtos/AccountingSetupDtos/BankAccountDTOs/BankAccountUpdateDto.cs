namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs
{
    public class BankAccountUpdateDto
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


    }
}
