namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesPersons
{
    public class SalesInvoiceSalesPersonCreateDto
    {

        public long SalesInvoiceId { get; set; }

        public long SalesPersonId { get; set; }
        public decimal Percentage { get; set; }


    }
}
