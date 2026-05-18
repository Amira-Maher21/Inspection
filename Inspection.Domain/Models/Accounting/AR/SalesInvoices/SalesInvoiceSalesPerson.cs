using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.AR.SalesInvoices
{
    public class SalesInvoiceSalesPerson : IAuditable
    {
        public long Id { get; set; }

        public long SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; } = null!;

        public long SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; } = null!;
        public decimal Percentage { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}