namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesPersons
{
    public class SalesInvoiceSalesPersonDto
    {
        public long Id { get; set; }

        public long SalesInvoiceId { get; set; }

        public long SalesPersonId { get; set; }
        public decimal Percentage { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
