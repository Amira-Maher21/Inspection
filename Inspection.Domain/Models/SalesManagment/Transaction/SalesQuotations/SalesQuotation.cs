using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using Inspection.Domain.Models.System.Taxes;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations
{
    public class SalesQuotation : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string CompanyId { get; private set; } = string.Empty;

        public string QuotationNumber { get; set; } = string.Empty;

        public long CustomerId { get; private set; }
        public Customer Customer { get; private set; } = null!;
        public long? InspectionRequestId { get; private set; }
        public InspectionRequest? InspectionRequest { get; private set; }
        public long? SalespersonId { get; private set; }
        public SalesPerson? Salesperson { get; private set; }
        public TaxType? TaxType { get; private set; }
        public long? TaxTypeId { get; private set; }
        public Currency? Currency { get; private set; }
        public long? CurrencyId { get; private set; }

        public DateTime? QuotationDate { get; private set; }
        public string VersionNumber { get; private set; } = string.Empty;
        public DateTime? ValidUntil { get; private set; }
        public string PONumber { get; private set; } = string.Empty;
        public decimal Discount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string TermsAndConditions { get; private set; } = string.Empty;
        public string CustomerNote { get; private set; } = string.Empty;

        public SalesQuotationDocumentStatus DocumentStatus { get; set; } = SalesQuotationDocumentStatus.Draft;
        public SalesQuotationStatus ApprovalStatus { get; private set; }
        public string DocumentStatusCancelled { get; set; } = string.Empty;
        public string DocumentStatusDeclined { get; private set; } = string.Empty;
        public List<SalesQuotationLine> SalesQuotationLines { get; set; } = null!;

        // series related
        public Series Series { get; private set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}