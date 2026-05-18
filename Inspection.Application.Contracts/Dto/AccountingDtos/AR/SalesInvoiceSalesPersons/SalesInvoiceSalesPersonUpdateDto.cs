namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesPersons
{
    public class SalesInvoiceSalesPersonUpdateDto
    {
        public long Id { get; set; }

        public long SalesInvoiceId { get; set; }

        public long SalesPersonId { get; set; }
        public decimal Percentage { get; set; }


    }
}
